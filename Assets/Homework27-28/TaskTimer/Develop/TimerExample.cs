using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimerExample : MonoBehaviour
{
    [SerializeField] private float _startTime;

    private TimerService _timerService;
    private TimerView _timerView;

    public TimerService TimerService => _timerService;

    private void Awake()
    {
        _timerView = FindAnyObjectByType<TimerView>();

        _timerService = new TimerService(_startTime);

        _timerView.Initialize(_timerService);
    }

    private void Update()
    {
        _timerService.Update();
    }

    public void StartTimer()
        => _timerService.StartTimer();

    public void StopOrContinuedTimer()
        => _timerService.StopOrContinuedTimer();

    public void ResetTimer()
        => _timerService.ResetTimer();
}
