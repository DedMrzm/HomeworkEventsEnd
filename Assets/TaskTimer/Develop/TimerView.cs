using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimerView : MonoBehaviour
{
    [SerializeField] private TypeOfTimerView _typeOfTimerView;

    [SerializeField]private TimerService _timerService;

    [SerializeField] private GameObject _startPanel;
    [SerializeField] private GameObject _playPanel;

    [SerializeField] private TMP_Text _textOfPlayButton;

    private ITimerView _currentTimerView;

    [Header("Dissapearing View")]
    [SerializeField] private GameObject _panelOfDisapearingView;
    [SerializeField] private GameObject _dissaperingGameObjectPrefab;
    [SerializeField] private Transform _parentOfDissapearingGameObjects;

    [Header("Slider View")]
    [SerializeField] private GameObject _panelOfSliderView;
    [SerializeField] private Slider _slider;

    private void Awake()
    {
        CreateTimer();

        _currentTimerView.Initialize();
    }

    private void Update()
    {
        if (_timerService.IsStarted)
        {
            _playPanel.SetActive(true);
            _startPanel.SetActive(false);
        }
        if( _timerService.IsStarted == false)
        {
            _playPanel.SetActive(false);
            _startPanel.SetActive(true);
        }
        if (_timerService.IsPaused)
        {
            _textOfPlayButton.text = "Continue";
        }
        if (_timerService.IsPaused == false)
        {
            _textOfPlayButton.text = "Stop";
        }
    }

    private void OnDestroy()
    {
        _currentTimerView.Deinitialize();
    }

    private void CreateTimer()
    {
        switch (_typeOfTimerView)
        {
            case TypeOfTimerView.DisappearingGameObjects:
                _panelOfDisapearingView.SetActive(true);
                _currentTimerView = new DisappearingGameObjectsTimerView(_dissaperingGameObjectPrefab, _parentOfDissapearingGameObjects, _timerService);
                break;
            case TypeOfTimerView.Slider:
                _panelOfSliderView.SetActive(true);
                _currentTimerView = new SliderTimerView(_slider, _timerService);
                break;
        }
    }
}
