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
        _slider.value = StartValueOfSlider;
    }
    public void OnChanged(float non1, float non2)
        => OnCount();

    public void OnReset()
    {
        _slider.value = StartValueOfSlider;
    }

    public void OnCount()
    {
        _slider.value = _timerService.CurrentTime.Value / (_timerService.StartTime);
    }
}
