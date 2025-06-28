using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICurrencyReciever
{
    event Action<int, string> Recieved;

    Dictionary<string, int> Currencies { get; set; }
}
