using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDataManager : MonoBehaviour
{
    public static ItemDataManager instance;

    private Dictionary<int, ItemData> ItemDatas = new Dictionary<int, ItemData>();

    private void Awake()
    {
        instance = this;

        ItemDataAllLoad();
    }

    private void ItemDataAllLoad()
    {
        ItemData[] loatItemDatas = Resources.LoadAll<ItemData>("ScriptableObject/Datas");
        foreach (ItemData data in loatItemDatas)
        {
            ItemDatas.Add(data.itemIndex, data);
        }
    }

    public ItemData GetItemData(int index)
    {
        if (ItemDatas.TryGetValue(index, out ItemData data))
        {
            return data;
        }
        return null;
    }
}
