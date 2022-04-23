using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsPool : MonoBehaviour
{
    public static ItemsPool Instance { get; private set; }

    private List<Item> _pool;

    public Item[] pool { get { return _pool.ToArray(); } }

    private void Awake()
    {
        if (!Instance)
        {
           Instance = this;

            Item[] save = JSONSaveLoad.ReadPoolJSON();
            if (save != null)
            {
                _pool = new List<Item>(save);
            }
            else
            {
                _pool = new List<Item>();
            }

            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        foreach (ItemSO item in Resources.LoadAll("Items"))
        {
            for (int i = 0; i < item.inShopAvailableCount; i++)
            {
                AddItemToPool(item);
            }
        }
    }

    public Item GetItem(int index) => _pool[index];
    public void RemoveItem(Item item) => _pool.Remove(item);
    public int GetLength() => _pool.Count;

    public void AddItemToPool(ItemSO itemSO)
    {
        switch (itemSO.itemType)
        {
            case ItemType.weapon:
                WeaponSO weaponSO = (WeaponSO)itemSO;
                Weapon weapon = new Weapon(weaponSO.itemType, weaponSO.rarity, weaponSO.title, weaponSO.damage);
                _pool.Add(weapon);
                break;
            case ItemType.armor:
                ArmorSO armorSO = (ArmorSO)itemSO;
                Armor armor = new Armor(armorSO.itemType, armorSO.rarity, armorSO.title, armorSO.defence);
                _pool.Add(armor);
                break;
            case ItemType.artifact:
                ArtifactSO artifactSO = (ArtifactSO)itemSO;
                Artifact artifact = new Artifact(artifactSO.itemType, artifactSO.rarity, artifactSO.title, artifactSO.stat, artifactSO.boostValue);
                _pool.Add(artifact);
                break;
            case ItemType.consumable:
                ConsumableSO consumableSO = (ConsumableSO)itemSO;
                Consumable consumable = new Consumable(consumableSO.itemType, consumableSO.rarity, consumableSO.title, consumableSO.stat,
                    consumableSO.boostValue, consumableSO.boostDuration);
                _pool.Add(consumable);
                break;
        }
    }

    public void AddItemToPool(Item item) => _pool.Add(item);
}
