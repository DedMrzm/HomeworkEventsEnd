using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class WalletView : MonoBehaviour
{
    private Dictionary<string, TMP_Text> _currencyTexts;

    [SerializeField] private TMP_Text _moneyText;
    [SerializeField] private TMP_Text _diamondText;
    [SerializeField] private TMP_Text _energyText;

    [SerializeField] private Wallet _wallet;

    private void Awake()
    {
        _wallet = FindAnyObjectByType<Wallet>();

        _currencyTexts = new Dictionary<string, TMP_Text>()
       {
           {"Money", _moneyText},
           {"Diamonds", _diamondText},
           {"Energy", _energyText},
       };

        foreach(string key in _wallet.Currencies.Keys)
        {
            _currencyTexts[key].text = _wallet.Currencies[key].ToString();
        }

        _wallet.Spended += OnChanged;
        _wallet.Recieved += OnChanged;
    }

    private void OnDestroy()
    {
        _wallet.Spended -= OnChanged;
        _wallet.Recieved -= OnChanged;
    }

    private void OnChanged(int spendedValue, string key)
    {
        _currencyTexts[key].text = _wallet.Currencies[key].ToString();
    }

}
