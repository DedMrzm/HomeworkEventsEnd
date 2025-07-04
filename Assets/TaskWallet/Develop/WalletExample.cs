using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalletExample : MonoBehaviour
{
    private WalletView _walletView;
    [SerializeField] private int _valueToSpendOrRecieve;

    [SerializeField] private GameObject PrefabOfWalletUI;
    [SerializeField] private GameObject PrefabOfEducationalUI;

    IReadOnlyList<Wallet> _wallets;

    private Wallet _wallet;

    private void Awake()
    {
        Instantiate(PrefabOfWalletUI);
        Instantiate(PrefabOfEducationalUI);

        _walletView = FindAnyObjectByType<WalletView>();

        _wallet = new Wallet(CurrenciesTypes.Money, CurrenciesTypes.Energy, CurrenciesTypes.Diamonds);

        _walletView.Initialize(_wallet);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            _wallet.Spend(CurrenciesTypes.Money, _valueToSpendOrRecieve);

        if (Input.GetKeyDown(KeyCode.Alpha2))
            _wallet.Recieve(CurrenciesTypes.Money, _valueToSpendOrRecieve);

        if (Input.GetKeyDown(KeyCode.Alpha3))
            _wallet.Spend(CurrenciesTypes.Diamonds, _valueToSpendOrRecieve); 
        
        if (Input.GetKeyDown(KeyCode.Alpha4))
            _wallet.Recieve(CurrenciesTypes.Diamonds, _valueToSpendOrRecieve); 
        
        if (Input.GetKeyDown(KeyCode.Alpha5))
            _wallet.Spend(CurrenciesTypes.Energy, _valueToSpendOrRecieve);

        if (Input.GetKeyDown(KeyCode.Alpha6))
            _wallet.Recieve(CurrenciesTypes.Energy, _valueToSpendOrRecieve);
    }
}
