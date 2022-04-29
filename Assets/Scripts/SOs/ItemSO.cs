using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSO : ScriptableObject
{
    public ItemType itemType;
    public Rarity rarity;
    public string title;
    public string imageName;
    public int inShopAvailableCount;
}
