using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    private Inventory _inventory;
    public InventorySlotUI[] uiSlots;

    private void Awake()
    {
        
    }

    private void Start()
    {
        for (int i = 0; i < uiSlots.Length; i++)
        {
            uiSlots[i].index = i;
        }
    }

    public void Init(Inventory inventory)
    {
        _inventory = inventory;
    }

    public void InventoryUIAllSlotUpdate()
    {
        for (int i = 0; i < _inventory.ItemList.Count; i++)
        {
            uiSlots[i].UpdateSlotToItemData(_inventory.ItemList[i]);
        }
    }
}
