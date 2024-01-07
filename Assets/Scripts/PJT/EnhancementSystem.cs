using UnityEngine;

public class EnhancementSystem : MonoBehaviour
{
    public Inventory inventory;
    public Sword sword;
    public int enhancementMaterialIndex = 0; // 강화 재료의 인덱스
    private int currentLevel = 1; // 현재 강화 레벨
    public bool enhancementSucceeded { get; private set; }

    // 강화 시도 메서드
    public void TryEnhance()
    {
        enhancementSucceeded = false; // 기본적으로 실패로 설정

        int requiredMaterials = RequiredMaterials(currentLevel);

        if (inventory.GetEnhancementMaterialCount(enhancementMaterialIndex) >= requiredMaterials)
        {
            EnhanceSword();
            inventory.SubtractItem(enhancementMaterialIndex, requiredMaterials);
            enhancementSucceeded = true; // 강화 성공
        }
        else
        {
            Debug.Log("강화 재료가 부족합니다.");
        }
    }

    // 검 강화 메서드
    private void EnhanceSword()
    {
        // 강화 로직 구현
        sword.damage *= 1.1f; // 예시: 데미지를 10% 증가
        sword.attackSpeed *= 0.9f; // 예시: 공격 속도를 10% 증가 (또는 감소)
        currentLevel++; // 강화 레벨 증가
    }

    // 필요한 재료 수량 계산 메서드
    private int RequiredMaterials(int level)
    {
        // 기본적으로 레벨만큼 재료가 필요
        int baseMaterials = level;

        // 추가 재료: 매 5레벨마다 5개씩 추가
        int additionalMaterials = (level - 1) / 5 * 5;

        // 총 필요한 재료 수량 = 기본 재료 수량 + 추가 재료 수량
        return baseMaterials + additionalMaterials;
    }
}
