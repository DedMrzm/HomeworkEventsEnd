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
    public event Action Counted;

    private float _startTime;

    private float _currentTime;

    public bool IsStarted;
    public bool IsPaused;

    public TimerService(float startTime)
    {
        _startTime = startTime;
        _currentTime = _startTime; 
    }

    public float CurrentTime => _currentTime;
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
        _currentTime -= Time.deltaTime;

        Debug.Log((int) _currentTime);

        if (_currentTime <= 0)
        {
            _currentTime = 0;
        }

        Counted?.Invoke();
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
        _currentTime = _startTime;
        IsStarted = false;
        IsPaused = false;

        Reseted?.Invoke();
    }

}
