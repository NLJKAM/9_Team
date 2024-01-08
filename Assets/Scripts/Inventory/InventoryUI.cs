using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InventoryUI : MonoBehaviour
{
    private Inventory _inventory;
    [SerializeField] private GameObject _inventoryWindow;
    [SerializeField] private GameObject _itemDetailPopupWindow;
    private ItemDetailInfoPopup _itemDetailInfoPopup;
    public Button _inventoryButton;
    private Button _closeButton;
    private Button _popupCloseButton;

    public InventorySlotUI[] uiSlots;
    public Sprite[] gradeOutlines;  // inspector에서 직접 파일 연결, 등급 순서에 맞게 차례대로 넣기

    private int _selectedSlot = -1;
    private bool _isOpen = false;

    private void Awake()
    {
        for (int i = 0; i < uiSlots.Length; i++)
        {
            uiSlots[i].SlotInit(i, this);
        }

        _itemDetailInfoPopup = _itemDetailPopupWindow.GetComponent<ItemDetailInfoPopup>();
        _closeButton = _inventoryWindow.transform.Find("CloseButton").GetComponent<Button>();
        _popupCloseButton = _itemDetailInfoPopup.transform.Find("CloseButton").GetComponent<Button>();
    }

    private void Start()
    {
        foreach (InventorySlotUI i in uiSlots)
        {
            i.SlotClear();
        }
        _itemDetailInfoPopup.PopupSlotInit(this);   // 팝업에도 보내줘야됨 ㅠㅠ
        _inventoryButton.onClick.AddListener(() => InventoryToggle());
        _closeButton.onClick.AddListener(() => InventoryToggle());
        _popupCloseButton.onClick.AddListener(() => _itemDetailInfoPopup.ItemInfoClose());
        _popupCloseButton.onClick.AddListener(() => SelectedOutlineUnEnable());
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
            _inventoryWindow.SetActive(true);
            _isOpen = true;
            AllSlotUIUpdate();
        }
        else
        {
            _inventoryWindow.SetActive(false);
            _itemDetailInfoPopup.ItemInfoClose();
            SelectedOutlineUnEnable();
            _isOpen = false;
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

        // 이전 슬롯 꺼주고
        SelectedOutlineUnEnable();
        _itemDetailInfoPopup.ItemInfoUpdate(item);
        // 새로 선택한 슬롯을 아웃라인 쳐주고 그 인덱스로 바꿈
        uiSlots[index].SlotSelectOutlineToggle();
        _selectedSlot = index;
        _itemDetailInfoPopup.ItemInfoOpen();
    }

    public bool SlotItemCheck(int index)
    {
        Item item = _inventory.ItemList[index];
        return item != null;
    }

    private void SelectedOutlineUnEnable()
    {
        if (_selectedSlot != -1)
        {
            uiSlots[_selectedSlot].SlotSelectOutlineToggle();
        }
        _selectedSlot = -1;
    }
}
