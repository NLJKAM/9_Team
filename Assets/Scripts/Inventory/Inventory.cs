using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
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
        
    }

    public void GetItem(int index, int amount = 1)
    {
        ItemData data = _itemDataManager.GetItemData(index);

        if (data.canStack)
        {
            // 같은 아이템이 있는지 검사
            Item item = _itemList.FirstOrDefault(item => item.Data.itemIndex == index);

            if (item != null)
            {
                // 추가가 가능한지 확인
                if (!item.IsMaxStack)
                {
                    item.AddAmount(amount);
                }
            }
            else
            {
                item = new Item(data);
                _itemList.Add(item);
                item.AddAmount(amount);
            }
        }
        else
        {
            Item item = new Item(data);
            _itemList.Add(item);
        }

        _inventoryUI.InventoryUIAllSlotUpdate();
    }

    public void Init(ItemDataManager itemDataManager)
    {
        _itemDataManager = itemDataManager;
    }
}
