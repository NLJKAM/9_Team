using UnityEngine;
using UnityEngine.UI;

public class EnhancementUI : MonoBehaviour
{
    public EnhancementSystem enhancementSystem;
    public Button enhanceButton;
    public Text materialsCountText;
    public Text feedbackText;
    // 기타 필요한 UI 요소 선언...

    void Start()
    {
        enhanceButton.onClick.AddListener(enhancementSystem.TryEnhance);
        UpdateUI();
    }

    void UpdateUI()
    {
        int materialIndex = enhancementSystem.enhancementMaterialIndex;
        materialsCountText.text = "재료 수량: " + enhancementSystem.inventory.GetEnhancementMaterialCount(materialIndex);
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
