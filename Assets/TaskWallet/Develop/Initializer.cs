using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Initializer : MonoBehaviour
{
    [SerializeField] private GameObject PrefabOfWalletUI;
    [SerializeField] private GameObject PrefabOfEducationalUI;

    private void Awake()
    {
        Instantiate(PrefabOfWalletUI);
        Instantiate(PrefabOfEducationalUI);
    }
}
