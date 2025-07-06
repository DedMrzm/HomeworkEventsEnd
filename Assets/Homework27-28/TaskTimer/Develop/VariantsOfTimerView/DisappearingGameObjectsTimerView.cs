using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DisappearingGameObjectsTimerView : ITimerView
{
    private TimerService _timerService;

    private List<GameObject> _disapperingGameObjects = new();

    private GameObject _disapperingGameObjectPrefab;
    private Transform _parent;

    private float _startTime;

    public DisappearingGameObjectsTimerView(GameObject disapperingGameObjectPrefab, Transform parent, TimerService timerService)
    {
        _disapperingGameObjectPrefab = disapperingGameObjectPrefab;
        _parent = parent;
        _timerService = timerService;

        _startTime = _timerService.StartTime;
    }

    public IReadonlyVariable<float> CurrentTime => _timerService.CurrentTime;

    public void Initialize()
    {
        _timerService.Started += OnStart;
        _timerService.Reseted += OnReset;
        _timerService.CurrentTime.Changed += OnChanged;
    }

    public void Deinitialize()
    {
        _timerService.Started -= OnStart;
        _timerService.Reseted -= OnReset;
        _timerService.CurrentTime.Changed -= OnChanged;
    }
    public void OnStart()
    {
        for (int i = (int) _startTime; i > 0; i--)
        {
            GameObject dissapearingGameObject = UnityEngine.Object.Instantiate(_disapperingGameObjectPrefab, _parent);
            _disapperingGameObjects.Add(dissapearingGameObject);
        }
    }

    public void OnReset()
    {
        foreach(GameObject gameObject in _disapperingGameObjects)
        {
            UnityEngine.Object.Destroy(gameObject);
        }
        _disapperingGameObjects.Clear();
    }

    public void OnCount()
    {
        if (_disapperingGameObjects.Count - 1 >= (int) _timerService.CurrentTime.Value)
        {
            int indexOfLastDissapearingGameObject = _disapperingGameObjects.Count - 1;
            GameObject lastDissapearingGameObject = _disapperingGameObjects[indexOfLastDissapearingGameObject];
            _disapperingGameObjects.Remove(lastDissapearingGameObject);
            UnityEngine.Object.Destroy(lastDissapearingGameObject);
        }
    }

    private void OnChanged(float non1, float non2)
        => OnCount();
}
