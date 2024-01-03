using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private ItemDataManager _itemDataManager;
    [SerializeField] private InventoryUI _inventoryUI;

    private List<Item> _itemList = new List<Item>();

    private void Awake()
    {
        _itemDataManager = ItemDataManager.instance;

        _inventoryUI.Init(this);
    }

    public void GetItem(int index, int amount = 1)
    {
        ItemData data = _itemDataManager.GetItemData(index);

        if (data.canStack)
        {

        }
        else
        {
            _itemList.Add(new Item(data));
        }
    }
}
