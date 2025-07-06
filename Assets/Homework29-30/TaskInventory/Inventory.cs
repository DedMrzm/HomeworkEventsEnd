using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Inventory
{
    private List<Item> _items = new();

    private int _maxSize;

    public Inventory(List<Item> items, int maxSize)
    {
        _items = items.OrderBy(item => item.ID).ToList();
        _maxSize = maxSize;
    }
    
    public int CurrentSize => _items.Count;

    public List<Item> Items => _items;
    
    public void Add(Item item)
    {
        if (CurrentSize >= _maxSize)
        {
            Debug.LogError("Уже максимальное количество предметов в инвентаре");
            return;
        }

        _items.Add(item);
        Debug.Log("Добавлен новый предмет!\n" + "Item ID: " + item.ID + "\nItem Count: " + item.Count);
    }

    public List<Item> GetItemsBy(int id, int count)
    {
        if(GetAllId().Contains(id) == false)
        {
            Debug.LogError("В инвентаре нет предмета с таким ID!");
            return null;
        }
        if(count > CurrentSize)
        {
            Debug.LogError("Вы пытаетесь взять больше предметов с таким ID, чем есть в инвентаре");
            return null;
        }

        List<Item> gettingItems = new List<Item>();

        for (int i = 0; i < count; i++)
        {
            Item item = _items.First(item => item.ID == id);

            _items.Remove(item);
            gettingItems.Add(item);
        }

        Debug.Log("Вы взяли несколько предметов, теперь инвентарь выглядит так: \n");
        ShowAllItems();

        Debug.Log("\nА забраны были эти предметы: ");
        foreach (Item item in gettingItems)
            Debug.Log("\nItem ID: " + item.ID + "\nItem Count: " + item.Count);

        return gettingItems;
    }

    public List<int> GetAllId()
        => _items.Select(item => item.ID).ToList();

    public void ShowAllItems()
    {
        Debug.ClearDeveloperConsole();
        Debug.Log("Вот все предметы в инвентаре:\n");

        foreach (Item item in _items)
            Debug.Log("Item ID: " + item.ID + "\nItem Count: " + item.Count);
    }
}


[Serializable]
public class Item
{
    [SerializeField] public int _id;
    [SerializeField] public int _count;

    public Item(int id, int count)
    {
        _id = id;
        _count = count;
    }

    public int ID => _id;
    public int Count => _count;
}