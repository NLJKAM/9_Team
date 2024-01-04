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

    // 강화 성공 시 검의 능력치를 업그레이드하는 메서드
    public void Enhance()
    {
        level++;
        attackPower *= 1.1f; // 예시로 지정해둔 것 이후에 변수이름이랑 바꿔줘야함
    }
}
