using System;
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

    private int _maxItemList;
    private List<Item> _itemList = new List<Item>();
    public List<Item> ItemList
    {
        get { return _itemList; }
    }

    private void Awake()
    {
        _inventoryUI.Init(this);
        _maxItemList = _inventoryUI.uiSlots.Length;
    }

    private void Start()
    {

    }

    public void AddItem(int index, int amount = 1)
    {
        if (_itemList.Count == _maxItemList) return;

        ItemData data = _itemDataManager.GetItemData(index);

        if (data.canStack)
        {
            // 같은 아이템이 있는지 검사
            Item item = FindItemInInventory(index);
            int itemPosition = -1;

            if (item != null)
            {
                itemPosition = _itemList.IndexOf(item);

                // 추가가 가능한지 확인
                if (!item.IsMaxStack)
                {
                    item.ModifyAmount(amount);
                    _inventoryUI.SlotUIUpdate(itemPosition);
                }
            }
            else
            {
                item = new Item(data);
                _itemList.Add(item);
                item.ModifyAmount(amount);
                _inventoryUI.SlotUIUpdate(_itemList.Count - 1);
            }
        }
        else
        {
            // 중첩 불가능한 아이템이면 여러칸에 계속 생성
            while (amount > 0)
            {
                Item item = new Item(data);
                _itemList.Add(item);
                item.ModifyAmount(1);
                _inventoryUI.SlotUIUpdate(_itemList.Count - 1);
                amount--;
            }
        }
    }

    public void SubtractItem(int index, int amount = 1)
    {
        // 같은 아이템이 있는지 검사
        Item item = FindItemInInventory(index);

        if (item == null) return;

        int itemPosition = _itemList.IndexOf(item);
        if (item.Amount >= amount)
        {
            item.ModifyAmount(-amount);
            _inventoryUI.SlotUIUpdate(itemPosition);
        }
        else
        {
            item.ModifyAmount(-item.Amount);
        }

        if (item.IsEmpty)
        {
            RemoveItem(item);
        }
    }

    public void RemoveItem(Item item)
    {
        _itemList.Remove(item);
        _inventoryUI.AllSlotUIUpdate();
    }

    public void Init(ItemDataManager itemDataManager)
    {
        _itemDataManager = itemDataManager;
    }

    private Item FindItemInInventory(int index)
    {
        return _itemList.FirstOrDefault(item => item.Data.itemIndex == index);
    }
}