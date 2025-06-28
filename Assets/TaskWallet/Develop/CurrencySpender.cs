using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencySpender
{
    private ICurrencySpender _currencySpender;

    public CurrencySpender(ICurrencySpender currencySpender)
    {
        _currencySpender = currencySpender;
    }

    public void Initialize()
    {
        _currencySpender.Spended += Spend;
    }

    public void Deinitialize()
    {
        _currencySpender.Spended -= Spend;
    }

    public void Spend(int spendedValue, string currencyName)
    {
        if(_currencySpender.Currencies[currencyName] <= 0)
        {
            _currencySpender.Currencies[currencyName] = 0;
        }
        else
        {
            _currencySpender.Currencies[currencyName] -= spendedValue;
        }
    }
}
