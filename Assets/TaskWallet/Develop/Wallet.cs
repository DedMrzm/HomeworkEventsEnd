using System;
using System.Collections.Generic;
using UnityEngine;

public class Wallet
{
    public event Action<int, CurrenciesTypes> Spended;
    public event Action<int, CurrenciesTypes> Recieved;

    public Dictionary<CurrenciesTypes, int> Currencies = new Dictionary<CurrenciesTypes, int>();

    public Wallet(params CurrenciesTypes[] currencies)
    {
        foreach (CurrenciesTypes currencyType in currencies)
            Currencies.Add(currencyType, 5);
    }

    public void Recieve(CurrenciesTypes currencyType, int value)
    {
        if (value < 0)
            return;

        Currencies[currencyType] += value;

        Recieved?.Invoke(value, currencyType);
    }

    public void Spend(CurrenciesTypes currencyType, int value)
    {
        if (value < 0 || Currencies[currencyType] - value < 0)
             return;

        Currencies[currencyType] -= value;

        Spended?.Invoke(value, currencyType);
    }
}
