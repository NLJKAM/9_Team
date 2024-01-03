using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSceneMonster : MonoBehaviour
{
    public float speed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(-speed*Time.deltaTime, 0, 0);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            SwordInformation.instance.currentFarmingGaug++;
            Destroy(gameObject);
        }
    }
}
