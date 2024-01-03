using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    private Inventory _inventory;
    public InventorySlotUI[] slots;

    private void Awake()
    {
        
    }

    private void Start()
    {
        
    }

    public void Init(Inventory inventory)
    {
        _inventory = inventory;
    }
}
