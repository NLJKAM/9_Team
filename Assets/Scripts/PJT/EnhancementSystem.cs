using UnityEngine;

public class EnhancementSystem : MonoBehaviour
{
    public Inventory inventory;
    public Sword sword;
    public int enhancementMaterialIndex = 0;
    private int currentLevel = 1;
    public bool enhancementSucceeded { get; private set; }

    public void TryEnhance()
    {
        int requiredMaterials = RequiredMaterials(currentLevel);

        if (inventory.GetEnhancementMaterialCount(enhancementMaterialIndex) >= requiredMaterials)
        {
            EnhanceSword();
            // 임시로 재료 소모를 비활성화
            // inventory.SubtractItem(enhancementMaterialIndex, requiredMaterials);
            enhancementSucceeded = true; // 강화 성공
        }
        else
        {
            Debug.Log("강화 재료가 부족합니다.");
            enhancementSucceeded = false; // 강화 실패
        }
    }

    private void EnhanceSword()
    {
        sword.damage *= 1.1f; // 데미지를 10% 증가
        sword.attackSpeed *= 0.9f; // 공격 속도를 10% 증가 (또는 감소)
        currentLevel++; // 강화 레벨 증가
    }

    private int RequiredMaterials(int level)
    {
        // 기본적으로 레벨만큼 재료가 필요
        int baseMaterials = level;
        // 추가 재료: 매 5레벨마다 5개씩 추가
        int additionalMaterials = (level - 1) / 5 * 5;
        // 총 필요한 재료 수량 = 기본 재료 수량 + 추가 재료 수량
        return baseMaterials + additionalMaterials;
    }
    public float CalculateEnhancementChance()
    {
        // 기본 확률은 80%, 매 5레벨마다 5%씩 감소
        float baseChance = 0.80f;
        int decreaseInterval = 5; // 감소 간격 (레벨)
        float decreaseAmount = 0.05f; // 감소량 (5%)

        float chanceDecrease = ((currentLevel - 1) / decreaseInterval) * decreaseAmount;
        // 최종 확률 계산, 0% 미만으로 내려가지 않도록 함
        float finalChance = Mathf.Max(baseChance - chanceDecrease, 0);
        return finalChance;
    }
}
