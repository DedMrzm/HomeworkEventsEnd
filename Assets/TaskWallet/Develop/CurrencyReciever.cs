using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencyReciever : MonoBehaviour
{
    private ICurrencyReciever _currencyRecievier;

    public CurrencyReciever(ICurrencyReciever currencyReciever)
    {
        _currencyRecievier = currencyReciever;
    }

    public void Initialize()
    {
        _currencyRecievier.Recieved += Recieve;
    }

    public void Deinitialize()
    {
        _currencyRecievier.Recieved -= Recieve;
    }

    public void Recieve(int recievedValue, string currencyName)
    {
        _currencyRecievier.Currencies[currencyName] += recievedValue;
    }
}
