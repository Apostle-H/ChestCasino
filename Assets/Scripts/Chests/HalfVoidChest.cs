using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HalfVoidChest : IChest
{
    public void Open()
    {
        float voidness = Random.Range(0.3f, 0.5f);

        for (int i = 0; i < Inventory.Instance.occupiedSlots.Count * voidness; i++)
        {
            Debug.Log(i);
            int removeItemIndex = Random.Range(0, Inventory.Instance.occupiedSlots.Count);
            Inventory.Instance.RemoveItem(Inventory.Instance.occupiedSlots[removeItemIndex]);
        }
    }
}
