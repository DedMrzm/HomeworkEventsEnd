using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimerExample : MonoBehaviour
{
    [SerializeField] private float _startTime;

    private TimerService _timerService;

    public TimerService TimerService => _timerService;

    private void Awake()
    {
        _timerService = new TimerService(_startTime);   
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
