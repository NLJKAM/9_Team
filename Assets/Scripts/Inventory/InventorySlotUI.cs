using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class InventorySlotUI : MonoBehaviour
{
    private Button _button;
    private Image _icon;
    private Image _gradeLine;
    private TextMeshProUGUI _amountText;
    private Outline _outline;

    private InventoryUI _inventoryUI;
    private int _index;
    private bool _selected;

    private void Awake()
    {
        _icon = transform.Find("ItemIcon").GetComponent<Image>();
        _amountText = GetComponentInChildren<TextMeshProUGUI>();
        _outline = GetComponent<Outline>();
        _gradeLine = transform.Find("GradeLine").GetComponent<Image>();
        _button = GetComponent<Button>();
    }
    private void Start()
    {
        _button.onClick.AddListener(() => SlotSelect()); // 연결이 귀찮아~
    }

    public void UpdateSlotToItemData(Item item)
    {
        // 스프라이트 변경
        _icon.gameObject.SetActive(true);
        _icon.sprite = item.Data.itemIcon;

        // 갯수 표기
        if (item.Amount > 1)
        {
            _amountText.gameObject.SetActive(true);
            _amountText.text = item.Amount.ToString();
        }
        else
        {
            _amountText.gameObject.SetActive(false);
        }

        //테두리 변경
        _gradeLine.gameObject.SetActive(true);
        _gradeLine.sprite = _inventoryUI.gradeOutlines[(int)item.Data.rarity];
    }

    public void SlotClear()
    {
        _icon.gameObject.SetActive(false);
        _gradeLine.gameObject.SetActive(false);
        _amountText.text = string.Empty;
    }

    public void SlotInit(int index, InventoryUI inventoryUI)
    {
        _index = index;
        _inventoryUI = inventoryUI;
    }

    public void SlotSelect()
    {
        if (_inventoryUI.SlotItemCheck(_index))
        {
            _inventoryUI.SlotItemInfo(_index);
            _selected = !_selected;
            _outline.enabled = _selected;
        }
    }
}
