using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDataManager : MonoBehaviour
{
    public static ItemDataManager instance;
    // 매니저를 전달받을 인벤토리 입니다. inspector에서 직접 연결이 필요합니다.
    [SerializeField] private Inventory _inventory;

    private Dictionary<int, ItemData> ItemDatas = new Dictionary<int, ItemData>();

    private void Awake()
    {
        instance = this;
        _inventory.Init(this);

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
