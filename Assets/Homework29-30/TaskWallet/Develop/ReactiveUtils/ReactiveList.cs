using System;
using System.Collections.Generic;

public class ReactiveList<T>
{
    public event Action<T> Added;
    public event Action<T> Removed;

    private List<T> _elements = new();

    public IReadOnlyList<T> Elements => _elements;

    public virtual void Add(T element)
    {
        _elements.Add(element);
        Added?.Invoke(element);
    }

    public virtual void Remove(T element)
    {
        _elements.Remove(element); //Тоже самое, что и базовый метод Remove, но с колбеком в виде ивента
        Removed?.Invoke(element);
    }
}
