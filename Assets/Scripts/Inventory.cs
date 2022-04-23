using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance { get; private set; }

    [SerializeField] private Transform inventoryPanel;

    public Item[] storedItems { get; private set; }
    public List<int> occupiedSlots { get; private set; } = new List<int>();

    private void Awake()
    {
        if (!Instance)
        {
            Instance = this;

            Item[] save = JSONSaveLoad.ReadInventoryJSON();
            if (save != null)
            {
                storedItems = save;
                for (int i = 0; i < storedItems.Length; i++)
                {
                    if (storedItems[i] != null)
                    {
                        inventoryPanel.GetChild(i).GetChild(0).gameObject.SetActive(true);

                        occupiedSlots.Add(i);
                    }
                }
            }
            else
            {
                storedItems = new Item[12];
            }

            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddItem(Item item)
    {
        for (int i = 0; i < storedItems.Length; i++)
        {
            if (storedItems[i] == null)
            {
                storedItems[i] = item;
                inventoryPanel.GetChild(i).GetChild(0).gameObject.SetActive(true);

                occupiedSlots.Add(i);
                break;
            }
        }
    }

    public void RemoveItem(int index)
    {
        if (index < 0 || index >= storedItems.Length || storedItems[index] == null)
            return;

        ItemsPool.Instance.AddItemToPool(storedItems[index]);
        storedItems[index] = null;

        occupiedSlots.Remove(index);

        inventoryPanel.GetChild(index).GetChild(0).gameObject.SetActive(false);

        JSONSaveLoad.WriteInventoryJSON();
    }
}
