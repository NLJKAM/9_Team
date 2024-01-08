using UnityEngine;
using UnityEngine.UI;

public class EnhancementUI : MonoBehaviour
{
    public EnhancementSystem enhancementSystem;
    public Button enhanceButton;
    public Text materialsCountText;
    public Text enhancementChanceText;
    public Text feedbackText;

    void Start()
    {
        enhanceButton.onClick.AddListener(delegate { TryEnhance(); });
        UpdateUI();
    }

    void UpdateUI()
    {
        // 인벤토리에서 강화 재료의 현재 수량을 가져와서 표시합니다.
        int materialCount = enhancementSystem.inventory.GetEnhancementMaterialCount(enhancementSystem.enhancementMaterialIndex);
        materialsCountText.text = "재료 수량: " + materialCount;

        // 강화 확률을 계산하여 표시합니다.
        float enhancementChance = enhancementSystem.CalculateEnhancementChance();
        enhancementChanceText.text = (enhancementChance * 100).ToString("F0") + "%";
    }

    public void TryEnhance()
    {
        enhancementSystem.TryEnhance();

        if (enhancementSystem.enhancementSucceeded)
        {
            feedbackText.text = "강화 성공!";
        }
        else
        {
            feedbackText.text = "강화 실패...";
        }

        UpdateUI();
    }
}
