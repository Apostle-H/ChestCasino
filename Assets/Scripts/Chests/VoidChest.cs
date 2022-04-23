using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoidChest : IChest
{
    public void Open()
    {
        for (int i = Inventory.Instance.occupiedSlots.Count; i > 0; i--)
        {
            Inventory.Instance.RemoveItem(Inventory.Instance.occupiedSlots[0]);
        }
    }
}
