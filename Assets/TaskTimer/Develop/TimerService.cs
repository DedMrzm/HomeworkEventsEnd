using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TimerService
{
    public event Action Started;
    public event Action Stoped;
    public event Action Continued;
    public event Action Reseted;

    private float _startTime;

    private ReactiveVariable<float> _currentTime;

    public bool IsStarted;
    public bool IsPaused;

    public TimerService(float startTime)
    {
        _currentTime = new ReactiveVariable<float>(startTime);

        _startTime = startTime; 
    }

    public IReadonlyVariable<float> CurrentTime => _currentTime;
    public float StartTime => _startTime;

    public void Update()
    {
        if (IsStarted == true && IsPaused == false)
        {
            Count();
        }
    }

    private void Count()
    {
        _currentTime.Value -= Time.deltaTime;

        Debug.Log((int) _currentTime.Value);

        if (_currentTime.Value <= 0)
        {
            _currentTime.Value = 0;
        }
    }

    public void StartTimer()
    {
        IsStarted = true;
        IsPaused = false;

        Started?.Invoke();
    }

    public void StopOrContinuedTimer()
    {
        if(IsPaused == false)
        {
            Continued?.Invoke();
            IsPaused = true;
        }
        else if (IsPaused == true)
        {
            Stoped?.Invoke();
            IsPaused = false;
        }
    }

    public void ResetTimer()
    {
        _currentTime.Value = _startTime;
        IsStarted = false;
        IsPaused = false;

        Reseted?.Invoke();
    }

}
