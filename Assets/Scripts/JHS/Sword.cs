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

    public List<GameObject> monstersLockOnQueue= new List<GameObject>();
    public static Sword instance;
    public Slider farmingGauge;

    private bool attack;
    private bool onFaint;
    private float attackDelayTime;
    private float faintDurationTime;
    private void Awake()
    {
        if (instance == null) 
        {
            instance = this; 
        }
    }
    void Update()
    {
        if(monstersLockOnQueue.Count != 0)
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
        if(currentFarmingGauge >= MaxFarmingGauge)
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
        if (collision.tag == "Monster" &&collision.gameObject == monstersLockOnQueue[0] && attack)
        {
            attack = false;
            collision.gameObject.GetComponent<MainSceneMonster>().hit = true;
            collision.gameObject.GetComponent<MainSceneMonster>().monsterHP -= damage;
        }
    }
}
