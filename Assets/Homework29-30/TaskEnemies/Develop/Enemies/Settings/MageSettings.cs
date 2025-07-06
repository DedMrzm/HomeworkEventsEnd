using System;
using UnityEngine;


[Serializable]
public class MageSettings : IEnemySettings
{
    [field: SerializeField, Min(0)] public int Mana { get; private set; }
    [field: SerializeField, Min(0)] public int Range { get; private set; }
    [field: SerializeField, Min(0)] public int Health { get; set; }
    [field: SerializeField, Min(0)] public int Speed { get; set; }
}
