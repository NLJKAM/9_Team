using UnityEngine;

public class EnhancementSystem : MonoBehaviour
{
    public Sword sword; // ��ȭ�� ���� ��
    public int enhancementMaterials = 10; // ���Ƿ� �����ص����� ���߿� ����
    public int requiredMaterialsPerLevel = 1; // ��ȭ�� ���Ǵ� ����� ����

    private void Start()
    {
        // �⺻ �� �ʱ�ȭ
        sword = new Sword(10.0f); // ���Ƿ� �����ص����� ���߿� ����
    }

    // ��ȭ �õ� �޼���
    public bool TryEnhance()
    {
        int requiredMaterials = sword.level * requiredMaterialsPerLevel;

        if (enhancementMaterials < requiredMaterials)
        {
            Debug.Log("��ȭ ��ᰡ �����մϴ�. �ʿ��� ���: " + requiredMaterials);
            return false;
        }

        float successChance = CalculateEnhanceSuccessChance(sword.level);

        if (Random.value < successChance)
        {
            sword.Enhance();
            enhancementMaterials -= requiredMaterials; // �ʿ��� ����� ����ŭ �Ҹ�
            Debug.Log("��ȭ ����! ���� ����: " + sword.level + ", ���� ���: " + enhancementMaterials);
            return true;
        }
        else
        {
            enhancementMaterials -= requiredMaterials; // �ʿ��� ����� ����ŭ �Ҹ�
            Debug.Log("��ȭ ����, ���� ���: " + enhancementMaterials);
            return false;
        }
    }

    // ��ȭ ���� Ȯ�� ��� �޼���
    private float CalculateEnhanceSuccessChance(int level)
    {
        //������ ���� ���� Ȯ���� �޶���
        return Mathf.Clamp(1.0f - (level * 0.05f), 0.1f, 1.0f);
    }
}
