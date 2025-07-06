using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Dragon : Enemy
{
    [SerializeField, Min(0)] private int _fireDamage;

    public void Initialize(int health, int speed, int fireDamage)
    {
        _fireDamage = fireDamage;

        base.Initialize(health, speed);
    }
}


