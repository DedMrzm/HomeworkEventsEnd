using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class OrkSettings : IEnemySettings
{
    [field: SerializeField, Min(0)] public int Strength { get; private set; }
    [field: SerializeField, Min(0)] public int Health { get; set; }
    [field: SerializeField, Min(0)] public int Speed { get; set; }
}
