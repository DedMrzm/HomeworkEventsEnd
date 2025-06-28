using System;

public interface ITimerView
{
    float CurrentTime { get; }

    void OnStart();

    void OnReset();

    void OnCount();

    void Initialize();

    void Deinitialize();
}
