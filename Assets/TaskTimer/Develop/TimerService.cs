using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TimerService : MonoBehaviour
{
    public event Action Started;
    public event Action Stoped;
    public event Action Continued;
    public event Action Reseted;
    public event Action Counted;

    [SerializeField] private float _startTime;

    private float _currentTime;

    private bool _isStarted;
    private bool _isPaused;

    public float CurrentTime => _currentTime;
    public float StartTime => _startTime;

    public bool IsStarted { get => _isStarted; set => _isStarted = value; }
    public bool IsPaused { get => _isPaused; set => _isPaused = value; }

    private void Awake()
    {
        Started += OnStartTimer;
        Continued += OnStopOrContinued;
        Stoped += OnStopOrContinued;
        Reseted += OnResetTimer;
        Counted += Count;

        _currentTime = _startTime;
    }

    private void Update()
    {
        if (_isStarted == true && _isPaused == false)
        {
            Counted?.Invoke();
        }
    }

    private void OnDestroy()
    {
        Started -= OnStartTimer;
        Continued -= OnStopOrContinued;
        Stoped -= OnStopOrContinued;
        Reseted -= OnResetTimer;
        Counted -= Count;
    }

    private void Count()
    {
        _currentTime -= Time.deltaTime;

        Debug.Log((int) _currentTime);

        if (_currentTime <= 0)
        {
            _currentTime = 0;
        }
    }

    private void OnStartTimer()
    {
        _isStarted = true;
        _isPaused = false;
    }

    private void OnStopOrContinued()
    {
        _isPaused = !_isPaused;
    }

    private void OnResetTimer()
    {
        _currentTime = _startTime;
        _isStarted = false;
        _isPaused = false;
    }

    public void StartTimer()
    => Started?.Invoke();
    
    public void StopTimer()
    => Stoped?.Invoke();

    public void ContinueTimer()
    => Continued?.Invoke();
    
    public void ResetTimer()
    => Reseted?.Invoke();

}
