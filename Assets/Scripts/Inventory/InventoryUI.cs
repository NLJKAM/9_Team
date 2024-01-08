using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class InventoryUI : MonoBehaviour
{
    private Inventory _inventory;
    [SerializeField] private GameObject _inventoryWindow;
    [SerializeField] private GameObject _itemDetailPopupWindow;
    private ItemDetailInfoPopup _itemDetailInfoPopup;

    public InventorySlotUI[] uiSlots;
    public Sprite[] gradeOutlines;  // inspector에서 직접 파일 연결, 등급 순서에 맞게 차례대로 넣기

    private bool _isOpen = false;

    private void Awake()
    {
        for (int i = 0; i < uiSlots.Length; i++)
        {
            uiSlots[i].SlotInit(i, this);
        }

        _itemDetailInfoPopup = _itemDetailPopupWindow.GetComponent<ItemDetailInfoPopup>();
    }

    private void Start()
    {
        foreach (InventorySlotUI i in uiSlots)
        {
            i.SlotClear();
        }
        _itemDetailInfoPopup.PopupSlotInit(this);   // 팝업에도 보내줘야됨 ㅠㅠ
    }

    public void Init(Inventory inventory)
    {
        _inventory = inventory;
    }

    // 온오프 함수이므로 이걸 버튼에 걸어주면 됩니다
    public void InventoryToggle()
    {
        if (!_isOpen)
        {
            _isOpen = true;
            _inventoryWindow.SetActive(true);
            AllSlotUIUpdate();
        }
        else
        {
            _isOpen = false;
            _inventoryWindow.SetActive(false);
        }
    }

    public void AllSlotUIUpdate()
    {
        for (int i = 0; i < uiSlots.Length; i++)
        {
            SlotUIUpdate(i);
        }
    }

    public void SlotUIUpdate(int index)
    {
        if (!_isOpen) return;

        if(_inventory.ItemList.Count > index)
            uiSlots[index].UpdateSlotToItemData(_inventory.ItemList[index]);
        else
            uiSlots[index].SlotClear();
    }

    public void SlotItemInfo(int index)
    {
        Item item = _inventory.ItemList[index];

        _itemDetailInfoPopup.ItemInfoUpdate(item);
        _itemDetailInfoPopup.ItemInfoOpen();
    }

    public bool SlotItemCheck(int index)
    {
        Item item = _inventory.ItemList[index];
        return item != null;
    }
}
