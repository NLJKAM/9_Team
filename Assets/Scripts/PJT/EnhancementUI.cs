using UnityEngine;
using UnityEngine.UI;

public class EnhancementUI : MonoBehaviour
{
    public EnhancementSystem enhancementSystem;
    public Button enhanceButton;
    public Text materialsCountText;
    public Text enhancementChanceText;
    public Text feedbackText;
    public GameObject enhancementPanel;

    void Start()
    {
        enhanceButton.onClick.AddListener(ToggleEnhancementPanel);
        UpdateUI();
    }

    void UpdateUI()
    {
        // 재료 수량과 강화 확률을 UI에 표시합니다.
        int materialCount = enhancementSystem.inventory.GetEnhancementMaterialCount(enhancementSystem.enhancementMaterialIndex);
        materialsCountText.text = materialCount.ToString();

        float enhancementChance = enhancementSystem.CalculateEnhancementChance();
        enhancementChanceText.text = (enhancementChance * 100).ToString("F0") + "%";
    }

    public void TryEnhance()
    {
        // 강화 시도를 수행합니다.
        enhancementSystem.TryEnhance();

        // 강화 성공 여부에 따라 피드백을 제공합니다.
        if (enhancementSystem.enhancementSucceeded)
        {
            feedbackText.text = "강화 성공!";
        }
        else
        {
            if (!enhancementSystem.isMaterialsEnough)
            {
                feedbackText.text = "강화 재료가 부족합니다.";
            }
            else
            {
                feedbackText.text = "강화 실패...";
            }
        }

        UpdateUI();
    }

    public void ToggleEnhancementPanel()
    {
        // 패널의 활성 상태를 토글합니다.
        bool isActive = !enhancementPanel.activeSelf;
        enhancementPanel.SetActive(isActive);
        Debug.Log("토글" + isActive);
    }
}
