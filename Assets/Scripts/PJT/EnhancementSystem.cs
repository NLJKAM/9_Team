using UnityEngine;

public class EnhancementSystem : MonoBehaviour
{
    public Sword sword; // 강화에 사용될 검
    public int enhancementMaterials = 10; // 임의로 지정해뒀으니 나중에 변경
    public int requiredMaterialsPerLevel = 1; // 강화에 사용되는 재료의 갯수

    private void Start()
    {
        // 기본 검 초기화
        sword = new Sword(10.0f); // 임의로 지정해뒀으니 나중에 변경
    }

    // 강화 시도 메서드
    public bool TryEnhance()
    {
        int requiredMaterials = sword.level * requiredMaterialsPerLevel;

        if (enhancementMaterials < requiredMaterials)
        {
            Debug.Log("강화 재료가 부족합니다. 필요한 재료: " + requiredMaterials);
            return false;
        }

        float successChance = CalculateEnhanceSuccessChance(sword.level);

        if (Random.value < successChance)
        {
            sword.Enhance();
            enhancementMaterials -= requiredMaterials; // 필요한 재료의 수만큼 소모
            Debug.Log("강화 성공! 현재 레벨: " + sword.level + ", 남은 재료: " + enhancementMaterials);
            return true;
        }
        else
        {
            enhancementMaterials -= requiredMaterials; // 필요한 재료의 수만큼 소모
            Debug.Log("강화 실패, 남은 재료: " + enhancementMaterials);
            return false;
        }
    }

    // 강화 성공 확률 계산 메서드
    private float CalculateEnhanceSuccessChance(int level)
    {
        //레벨에 따라 성공 확률이 달라짐
        return Mathf.Clamp(1.0f - (level * 0.05f), 0.1f, 1.0f);
    }
}
