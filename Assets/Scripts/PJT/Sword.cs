using System;

[Serializable]
public class Sword
{
    public int level = 1;
    public float attackPower;

    public Sword(float baseAttackPower)
    {
        attackPower = baseAttackPower;
    }

    // ��ȭ ���� �� ���� �ɷ�ġ�� ���׷��̵��ϴ� �޼���
    public void Enhance()
    {
        level++;
        attackPower *= 1.1f; // ���÷� �����ص� �� ���Ŀ� �����̸��̶� �ٲ������
    }
}
