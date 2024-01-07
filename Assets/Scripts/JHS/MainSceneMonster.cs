using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSceneMonster : MonoBehaviour
{
    public float speed;
    public bool move;
    public float monsterHP;
    public bool hit;
    public int farmingValue;
    
    private SpriteRenderer spr;
    private Vector3 playerPos;
    private void Awake()
    {
        spr = GetComponent<SpriteRenderer>();
    }
    void Start()
    {
        playerPos = new Vector3(0, 0, 0);
        playerPos -= transform.position;
    }

    void Update()
    {
        MonsterMove();
        MonsterHit();
        MonsterDie();
    }
    public void MonsterDie()
    {
        if (monsterHP <= 0)
        {
            Sword.instance.monstersLockOnQueue.Remove(gameObject);
            Sword.instance.FarmingMonsterGauge(farmingValue);
            Destroy(gameObject);
        }
    }
    private void MonsterHit()
    {
        if (hit)
        {
            hit = false;
            StartCoroutine("HitEffect");
        }
    }
    IEnumerator HitEffect()
    {
        spr.color = Color.red;
        yield return new WaitForSeconds(0.05f);
        spr.color = Color.white;
    }
    private void MonsterMove()
    {
        if (move)
        {
            transform.position += speed * playerPos * Time.deltaTime * 0.2f;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            move = false;
            Sword.instance.LockOnQueue(gameObject);
        }
    }
}
