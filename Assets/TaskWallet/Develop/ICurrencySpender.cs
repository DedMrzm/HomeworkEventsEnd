using System;
using System.Collections.Generic;

public interface ICurrencySpender
{
    event Action<int, string> Spended;

    Dictionary<string, int> Currencies { get; set; }
}
