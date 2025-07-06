using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Ork : Enemy
{
    [field: SerializeField, Min(0)] private int _strength;

    public void Initialize(int health, int speed, int strength)
    {
        base.Initialize(health, speed);
        _strength = strength;
    }
}
