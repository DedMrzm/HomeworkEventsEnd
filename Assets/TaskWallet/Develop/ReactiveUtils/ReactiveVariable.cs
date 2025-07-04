using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactiveVariable<T> : IReadonlyVariable<T> where T : IEquatable<T>
{
    public event Action<T, T> Changed;

    private T _value;

    public ReactiveVariable()
    {
        _value = default(T);
    }

    public ReactiveVariable(T value)
    {
        _value = value;
    }

    public T Value
    {
        get => _value;

        set
        {
            T oldValue = _value;

            _value = value;

            if(oldValue.Equals(_value)== false)
            {
                Changed?.Invoke(oldValue, _value);
            }
        }
    }
}
