using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    public Inventory inventory;
    public TMP_InputField itemIndex;
    public TMP_InputField addAmount;

    public void ItemInit()
    {
        int index = Convert.ToInt32(itemIndex.text);
        int amount = Convert.ToInt32(addAmount.text);

        if (index >= 1)
        {
            if (amount >= 0)
            {
                inventory.GetItem(index, amount);
            }
        }
    }
}
