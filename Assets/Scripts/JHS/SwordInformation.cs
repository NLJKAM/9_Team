using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SwordInformation : MonoBehaviour
{
    public float MaxFarmingGaug;
    public float currentFarmingGaug;


    public static SwordInformation instance;
    private void Awake()
    {
        if (instance == null) 
        {
            instance = this; 
        }
    }
    void Update()
    {
        
    }
}
