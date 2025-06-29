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
            _currencyTexts[currencyType].text = _wallet.Currencies[currencyType].ToString();
        }

        _wallet.Spended += OnChanged;
        _wallet.Recieved += OnChanged;
    }

    private void OnDestroy()
    {
        _wallet.Spended -= OnChanged;
        _wallet.Recieved -= OnChanged;
    }

    private void OnChanged(int spendedValue, CurrenciesTypes key)
    {
        _currencyTexts[key].text = _wallet.Currencies[key].ToString();
    }

}
