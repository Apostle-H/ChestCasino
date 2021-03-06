using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item
{
    public ItemType itemType;
    public Rarity rarity;
    public string title;
    public string imageName;

    public Item(ItemType itemType, Rarity rarity, string title, string mainSprite)
    {
        this.itemType = itemType;
        this.rarity = rarity;
        this.title = title;
        this.imageName = mainSprite;
    }

    public override string ToString()
    {
        return $"It is {rarity} {itemType}, called {title}";
    }
}

[System.Serializable]
public class Weapon : Item
{
    public int damage;

    public Weapon(ItemType itemType, Rarity rarity, string title, string mainSprite, int damage) : base(itemType, rarity, title, mainSprite)
    {
        this.damage = damage;
    }

    public override string ToString()
    {
        return base.ToString() + $"\nDamage {damage}";
    }
}

[System.Serializable]
public class Armor : Item
{
    public int defence;

    public Armor(ItemType itemType, Rarity rarity, string title, string mainSprite, int defence) : base(itemType, rarity, title, mainSprite)
    {
        this.defence = defence;
    }

    public override string ToString()
    {
        return base.ToString() + $"\nDefence {defence}";
    }
}

[System.Serializable]
public class Artifact : Item
{
    public Stat stat;
    public int boostValue;

    public Artifact(ItemType itemType, Rarity rarity, string title, string mainSprite, Stat stat, int boostValue)
        : base(itemType, rarity, title, mainSprite)
    {
        this.stat = stat;
        this.boostValue = boostValue;
    }

    public override string ToString()
    {
        return base.ToString() + $"\nGives {stat} stat boost + {boostValue}";
    }
}

[System.Serializable]
public class Consumable : Artifact
{
    public float boostDuration;

    public Consumable(ItemType itemType, Rarity rarity, string title, string mainSprite, Stat stat, int boostValue, float boostDuration)
        : base(itemType, rarity, title, mainSprite, stat, boostValue)
    {
        this.boostDuration = boostDuration;
    }

    public override string ToString()
    {
        return base.ToString() + $"\neffect duration {boostValue}";
    }
}
