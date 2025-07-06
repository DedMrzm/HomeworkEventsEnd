using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InventoryExample : MonoBehaviour
{
    private const KeyCode AddItemCode = KeyCode.Alpha1;
    private const KeyCode GetItemsCode = KeyCode.Alpha2;
    private const KeyCode ShowAllCode = KeyCode.Alpha3;

    private Inventory _inventory;

    [SerializeField] private int _countOfTakingItems;

    [Header("Invenory Settings")]
    [SerializeField] private int _maxSize;
    [SerializeField] private List<Item> _items;

    private void Awake()
    {
        _inventory = new Inventory(_items, _maxSize);
    }

    [System.Obsolete]
    private void Update()
    {
        if (Input.GetKeyDown(AddItemCode))
        {
            _inventory.Add(new Item(Random.RandomRange(0,100), Random.RandomRange(0, 100)));
        }
        if(Input.GetKeyDown(GetItemsCode))
        {
            if(_inventory.CurrentSize > 0)
            {
                _inventory.GetItemsBy(_inventory.Items[0].ID, _countOfTakingItems);
            }
            else
            {
                Debug.LogError("Инвентарь пуст!");
            }
        }
        if(Input.GetKeyDown(ShowAllCode))
        {
            _inventory.ShowAllItems();
        }
    }

    private void OnValidate()
    {
        
    }
}