using UnityEngine;

public class EnhancementSystem : MonoBehaviour
{
    public Inventory inventory;
    public Sword sword;
    public int enhancementMaterialIndex = 0;
    public int currentLevel = 0;
    public bool enhancementSucceeded { get; private set; }
    public float enhancementChanceDecrement = 0.05f;

    public void TryEnhance()
    {
        enhancementSucceeded = false;
        int requiredMaterials = RequiredMaterials(currentLevel);

        if (inventory.GetEnhancementMaterialCount(enhancementMaterialIndex) >= requiredMaterials)
        {
            float currentChance = CalculateEnhancementChance();
            if (Random.value <= currentChance)
            {
                EnhanceSword();
                // 임시로 재료 소모를 비활성화
                // inventory.SubtractItem(enhancementMaterialIndex, requiredMaterials);
                enhancementSucceeded = true;
            }
            else
            {
                Debug.Log("강화에 실패했습니다.");
            }
        }
        else
        {
            Debug.Log("강화 재료가 부족합니다.");
        }
    }

    private void EnhanceSword()
    {
        sword.damage *= 1.1f;
        sword.attackSpeed *= 0.9f;
        currentLevel++;
    }

    private int RequiredMaterials(int level)
    {
        // 기본적으로 레벨만큼 재료가 필요
        int baseMaterials = level;
        // 추가 재료: 매 5레벨마다 5개씩 추가
        int additionalMaterials = (level - 1) / 5 * 5;
        return baseMaterials + additionalMaterials;
    }

   public float CalculateEnhancementChance()
    {
        float baseChance = 0.80f; // 기본 80% 확률
        // 강화 확률은 5레벨마다 감소하게 설정해뒀습니다.
        return Mathf.Clamp(baseChance - (currentLevel / 5) * enhancementChanceDecrement, 0.0f, 1.0f);
    }
}