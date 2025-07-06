using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class DragonSettings : IEnemySettings
{
    [field: SerializeField, Min(0)] public int FireDamage { get; private set; }
    [field: SerializeField, Min(0)] public int Health { get; set; }
    [field: SerializeField, Min(0)] public int Speed { get; set; }
}
