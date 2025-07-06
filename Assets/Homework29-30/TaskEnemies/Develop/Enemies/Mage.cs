using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Mage : Enemy
{
    [SerializeField, Min(0)] private int _mana;
    [SerializeField, Min(0)] private int _range;

    public void Initialize(int health, int speed, int mana, int range)
    {
        base.Initialize(health, speed);

        _mana = mana;
        _range = range;
    }

}
