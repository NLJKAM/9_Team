using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    public float spawnTime;
    public GameObject monster01;
    public float spawnYPosition;
    private float time;
    // Update is called once per frame
    void Update()
    {
        OnSpawn();
    }
    public void OnSpawn()
    {
        time += Time.deltaTime;
        if(spawnTime < time)
        {
            time = 0;
            Instantiate(monster01,MonsterPositionSetting(spawnYPosition),Quaternion.identity);
        }
    }
    Vector3 MonsterPositionSetting(float Y)
    {
        float randomY = Random.RandomRange(-Y, Y);
        return new Vector3(gameObject.transform.position.x, gameObject.transform.position.y+randomY, 0);
    }
}
