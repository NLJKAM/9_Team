using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlotUI : MonoBehaviour
{
    private Button _button;
    private Image _icon;
    private TextMeshProUGUI _amountText;
    private Outline _outline;

    [HideInInspector] public int index;

    private void Awake()
    {
        _icon = transform.Find("ItemIcon").GetComponent<Image>();
        _amountText = GetComponentInChildren<TextMeshProUGUI>();
        _outline = GetComponentInChildren<Outline>();
    }

    public void UpdateSlotToItemData (Item item)
    {
        _icon.sprite = item.Data.itemIcon;
        _amountText.text = item.Amount.ToString();
    }
}
