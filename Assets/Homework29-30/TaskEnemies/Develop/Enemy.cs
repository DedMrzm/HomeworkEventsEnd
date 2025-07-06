using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [field: SerializeField] public TypeOfEnemy TypeOfEnemy { get; private set; }

    [SerializeField, Min(0)] private int _health;
    [SerializeField, Min(0)] private int _speed;

    protected void Initialize(int health, int speed)
    {
        _health = health;
        _speed = speed;
    }

}
