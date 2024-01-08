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
        enhanceButton.onClick.AddListener(() => ToggleEnhancementPanel(true));
        UpdateUI();
    }

    void UpdateUI()
    {

        int materialCount = enhancementSystem.inventory.GetEnhancementMaterialCount(enhancementSystem.enhancementMaterialIndex);
        materialsCountText.text = materialCount.ToString();

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


    public void ToggleEnhancementPanel(bool isActive)
    {
        Debug.Log("토글 " + isActive);
        enhancementPanel.SetActive(isActive);
    }
}
