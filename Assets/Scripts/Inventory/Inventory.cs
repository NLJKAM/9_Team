using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    // itemDataManager가 보내줍니다. 매니저한테 Inventory를 연결해주면 됩니다.
    private ItemDataManager _itemDataManager;
    [SerializeField] private InventoryUI _inventoryUI;

    private List<Item> _itemList = new List<Item>();
    public List<Item> ItemList
    {
        get { return _itemList; }
    }

    private void Awake()
    {
        _inventoryUI.Init(this);
    }

    private void Start()
    {
        GetItem(1);
    }

    public void GetItem(int index)
    {
        ItemData data = _itemDataManager.GetItemData(index);

        if (data.canStack)
        {

        }
        else
        {
            _itemList.Add(new Item(data));
            _inventoryUI.InventoryUIAllSlotUpdate();
        }
    }

    public void Init(ItemDataManager itemDataManager)
    {
        _itemDataManager = itemDataManager;
    }
}
