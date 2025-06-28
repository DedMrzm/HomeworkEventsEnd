using System;
using System.Collections.Generic;
using UnityEngine;

public class Wallet : MonoBehaviour, ICurrencySpender, ICurrencyReciever
{
    public event Action<int, string> Spended;
    public event Action<int, string> Recieved;

    public Dictionary<string, int> Currencies { get; set; }

    [SerializeField] private int _valueToSpend;
    [SerializeField] private int _valueToRecieve;

    private CurrencySpender _currencySpender;
    private CurrencyReciever _currencyReciever;

    [SerializeField] private int _money;
    [SerializeField] private int _diamonds;
    [SerializeField] private int _energy;

    private void Awake()
    {
        Currencies = new Dictionary<string, int>()
        {
            {"Money", 5 },
            {"Diamonds", 5},
            {"Energy", 5},
        };

        _currencyReciever = new CurrencyReciever(this);
        _currencySpender = new CurrencySpender(this);

        _currencySpender.Initialize();
        _currencyReciever.Initialize();
    }

    private void OnDestroy()
    {
        _currencySpender.Deinitialize();
        _currencyReciever.Deinitialize();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Spended?.Invoke(_valueToSpend, "Money");
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Recieved?.Invoke(_valueToRecieve, "Money");
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Spended?.Invoke(_valueToSpend, "Diamonds");
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            Recieved?.Invoke(_valueToRecieve, "Diamonds");
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            Spended?.Invoke(_valueToSpend, "Energy");
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            Recieved?.Invoke(_valueToRecieve, "Energy");
        }

        _money = Currencies["Money"];
        _diamonds = Currencies["Diamonds"];
        _energy = Currencies["Energy"];
    }
}
