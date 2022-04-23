using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleChest : IChest
{
    private int _lootAmount;

    public SimpleChest(int lootAmount)
    {
        _lootAmount = lootAmount;
    }

    public void Open()
    {
        if (ItemsPool.Instance.GetLength() < 1)
            return;

        for (int i = 0; i < _lootAmount; i++)
        {
            Item tempItem = ItemsPool.Instance.GetItem(Random.Range(0, ItemsPool.Instance.GetLength()));
            Inventory.Instance.AddItem(tempItem);
            ItemsPool.Instance.RemoveItem(tempItem);
        }
    }
}
