using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderTimerView : ITimerView
{
    private const float StartValueOfSlider = 1f;

    private TimerService _timerService;

    private Slider _slider;

    public SliderTimerView(Slider slider, TimerService timeService)
    {
        _timerService = timeService;
        _slider = slider;
    }

    public float CurrentTime => _timerService.CurrentTime;

    public void Initialize()
    {
        _timerService.Started += OnStart;
        _timerService.Reseted += OnReset;
        _timerService.Counted += OnCount;
    }

    public void Deinitialize()
    {
        _timerService.Started -= OnStart;
        _timerService.Reseted -= OnReset;
        _timerService.Counted -= OnCount;
    }

    public void OnStart()
    {
        _slider.value = StartValueOfSlider;
    }
    public void OnCount()
    {
        _slider.value = _timerService.CurrentTime / (_timerService.StartTime);
    }

    public void OnReset()
    {
        _slider.value = StartValueOfSlider;
    }

}
