using UnityEngine;
public class EnhancementSystem : MonoBehaviour
{
    public Inventory inventory;
    public Sword sword;
    public int enhancementMaterialIndex = 0;
    public int currentLevel = 1;
    public bool enhancementSucceeded { get; private set; }
    public float enhancementChanceDecrement = 0.05f;
    public bool isMaterialsEnough { get; private set; }
    public void TryEnhance()
    {
        int requiredMaterials = RequiredMaterials(currentLevel);
        if (inventory.HasEnhancementMaterials() && inventory.GetTotalEnhancementMaterialsCount() >= requiredMaterials)
        {
            float currentChance = CalculateEnhancementChance();
            if (Random.value <= currentChance)
            {
                EnhanceSword();
                // 주석을 해제하여 실제 게임에서 재료를 소모하도록 할 수 있습니다.
                inventory.SubtractItem(enhancementMaterialIndex, requiredMaterials);
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
        if (currentLevel % 5 == 0) //스프라이트를 5레벨마다 변경해줍니다.
        {
            sword.UpdateSwordAppearance(currentLevel);
        }
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