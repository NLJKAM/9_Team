using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Sword : MonoBehaviour
{
    [Header("Gauge")]
    public float MaxFarmingGauge;
    public float currentFarmingGauge;

    [Header("State")]
    public float damage;
    public float attackSpeed;
    public float swordHP;

    [Header("Tendency")]
    public float holyTendency;
    public float evilTendency;

    public List<GameObject> monstersLockOnQueue = new List<GameObject>();
    public static Sword instance;
    public Slider farmingGauge;

    private bool attack;
    private bool onFaint;
    private float attackDelayTime;
    private float faintDurationTime;
    public Sprite[] levelSprites;
    private SpriteRenderer spriteRenderer;
    public Sprite[] holyLevelSprites;
    public Sprite[] evilLevelSprites;
    private int minLevelForTendency = 5;
    private float minTendencyValue = 50.0f;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        if (monstersLockOnQueue.Count != 0)
        {
            AttackTarget();
        }
        OnFaint();
    }
    public void AttackTarget()
    {
        attackDelayTime += Time.deltaTime;
        if (attackDelayTime > attackSpeed)
        {
            attackDelayTime = 0;
            attack = true;
        }
    }
    public void OnFaint()
    {
        if (swordHP <= 0)
        {
            onFaint = true;
        }
    }
    public void LockOnQueue(GameObject targetQueue)
    {
        monstersLockOnQueue.Add(targetQueue);
    }
    public void FarmingMonsterGauge(int monsterFarmingValue)
    {
        currentFarmingGauge += monsterFarmingValue;
        if (currentFarmingGauge >= MaxFarmingGauge)
        {
            currentFarmingGauge = MaxFarmingGauge;
        }
        FarmingGaugeSet();
    }
    public void FarmingGaugeSet()
    {
        farmingGauge.value = currentFarmingGauge / MaxFarmingGauge;
    }
    private void OnTriggerEnter2D(Collider2D collision)//아무도 없을때 첫타를 위한 부분
    {
        if (collision.tag == "Monster" && collision.gameObject == monstersLockOnQueue[0])
        {
            collision.gameObject.GetComponent<MainSceneMonster>().hit = true;
            collision.gameObject.GetComponent<MainSceneMonster>().monsterHP -= damage;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Monster" && collision.gameObject == monstersLockOnQueue[0] && attack)
        {
            attack = false;
            collision.gameObject.GetComponent<MainSceneMonster>().hit = true;
            collision.gameObject.GetComponent<MainSceneMonster>().monsterHP -= damage;
        }
    }
    public void UpdateSwordAppearance(int level)
    {

        if (level >= minLevelForTendency)
        {
            if (holyTendency >= minTendencyValue)
            {

                int spriteIndex = (level / 5) - 1;
                if (spriteIndex >= 0 && spriteIndex < holyLevelSprites.Length)
                {
                    spriteRenderer.sprite = holyLevelSprites[spriteIndex];
                }
            }
            else if (evilTendency >= minTendencyValue)
            {
                int spriteIndex = (level / 5) - 1;
                if (spriteIndex >= 0 && spriteIndex < evilLevelSprites.Length)
                {
                    spriteRenderer.sprite = evilLevelSprites[spriteIndex];
                }
            }
        }
    }
}
