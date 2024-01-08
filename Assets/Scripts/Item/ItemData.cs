using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    GrowthItems,
    Resources
}

public enum Rarity
{
    Normal,
    Rare,
    Epic,
    Legendary,
    Mystic
}

[CreateAssetMenu(fileName = "DefaultItemsData", menuName = "ItemDatas/newItemData")]
public class ItemData : ScriptableObject
{
    [Header("Base Info")]
    public int itemIndex;
    public string itemName;
    [TextArea (3, 6)]
    public string description;
    public ItemType itemtype;
    public Rarity rarity;
    public Sprite itemIcon;

    [Header("Item price")]
    public int salePrice;

    [Header("Stacking")]
    public bool canStack;
    public int maxStack;

    [Header("Growth Info")]
    public int experience;
}
