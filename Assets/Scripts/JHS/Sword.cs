using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Sword : MonoBehaviour
{
    [Header("Gauge")]
    public float MaxFarmingGauge;
    public float currentFarmingGauge;

    [Header("Attack")]
    public float damage;
    public float attackSpeed;

    public List<GameObject> monstersLockOnQueue= new List<GameObject>();
    public static Sword instance;

    public bool attack;
    private float time;
    private GameObject playerAttackTarget;
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
    }
    public void AttackTarget()
    {
        time += Time.deltaTime;
        if (time > attackSpeed)
        {
            time = 0;
            attack = true;
        }
    }
    public void LockOnQueue(GameObject targetQueue)
    {
        monstersLockOnQueue.Add(targetQueue);
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
