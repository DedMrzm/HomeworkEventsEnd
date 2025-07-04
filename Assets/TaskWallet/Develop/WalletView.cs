using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WalletView : MonoBehaviour
{
    private Dictionary<CurrenciesTypes, TMP_Text> _currencyTexts = new Dictionary<CurrenciesTypes, TMP_Text>();

    [SerializeField] private TMP_Text _moneyText;
    [SerializeField] private TMP_Text _diamondText;
    [SerializeField] private TMP_Text _energyText;

    private Wallet _wallet;

    public void Initialize(Wallet wallet)
    {
        _wallet = wallet;

        _currencyTexts.Add(CurrenciesTypes.Money, _moneyText);
        _currencyTexts.Add(CurrenciesTypes.Energy, _energyText);
        _currencyTexts.Add(CurrenciesTypes.Diamonds, _diamondText);

        foreach (CurrenciesTypes currencyType in _wallet.Currencies.Keys)
        {
            _currencyTexts[currencyType].text = _wallet.Currencies[currencyType].Value.ToString();

            _wallet.Currencies[currencyType].Changed += OnChanged;
        }
    }

    private void OnDestroy()
    {
        foreach(ReactiveVariable<int> reactiveVariable in _wallet.Currencies.Values)
        {
            reactiveVariable.Changed -= OnChanged;
        }
    }

    private void OnChanged(int non1, int non2)
    {
        foreach (CurrenciesTypes currencyType in _wallet.Currencies.Keys)
        {
            _currencyTexts[currencyType].text = _wallet.Currencies[currencyType].Value.ToString();
        }
    }

}
