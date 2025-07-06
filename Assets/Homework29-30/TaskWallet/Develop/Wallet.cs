using System;
using System.Collections.Generic;
using UnityEngine;

public class Wallet
{
    public Dictionary<CurrenciesTypes, ReactiveVariable<int>> Currencies = new Dictionary<CurrenciesTypes, ReactiveVariable<int>>();

    public Wallet(params CurrenciesTypes[] currencies)
    {
        foreach (CurrenciesTypes currencyType in currencies)
            Currencies.Add(currencyType, new ReactiveVariable<int>());
    }

    public void Recieve(CurrenciesTypes currencyType, int recievedCurrency)
    {
        if (recievedCurrency < 0)
            return;

        Currencies[currencyType].Value += recievedCurrency;
    }

    public void Spend(CurrenciesTypes currencyType, int spendedCurrency)
    {
        if (spendedCurrency < 0 || Currencies[currencyType].Value - spendedCurrency < 0)
             return;

        Currencies[currencyType].Value -= spendedCurrency;
    }
}
