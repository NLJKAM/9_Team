using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemDetailInfoPopup : MonoBehaviour
{
    public TextMeshProUGUI itemName;
    public TextMeshProUGUI itemType;
    public TextMeshProUGUI itemAmount;
    public TextMeshProUGUI itemDescription;
    private InventorySlotUI _inventorySlot;
    private TextMeshProUGUI _amountText;
    private Button _slotButton;

    private string[] gradeText = new string[] { "성장용 무기", "재료" };

    private void Awake()
    {
        GameObject slot = transform.Find("Info").Find("Slot").gameObject;
        _inventorySlot = slot.GetComponent<InventorySlotUI>();
        _slotButton = slot.GetComponent<Button>();
        _amountText = slot.GetComponentInChildren<TextMeshProUGUI>();
    }

    private void Start()
    {
        _slotButton.enabled = false;
        _amountText.enabled = false;
        gameObject.SetActive(false);
    }

    public void ItemInfoUpdate(Item item)
    {
        itemName.text = item.Data.itemName;
        itemType.text = gradeText[(int)item.Data.itemtype];
        itemAmount.text = item.Amount.ToString();
        _inventorySlot.UpdateSlotToItemData(item);
        itemDescription.text = item.Data.description;
    }

    public void ItemInfoOpen()
    {
        if (!gameObject.activeInHierarchy)
        {
            gameObject.SetActive(true);
        }
        PopupPositionUpdate();
    }

    public void ItemInfoClose()
    {
        gameObject.SetActive(false);
    }

    public void PopupPositionUpdate()
    {

    }

    public void PopupSlotInit(InventoryUI inventoryUI)
    {
        _inventorySlot.SlotInit(0, inventoryUI);
    }
}
