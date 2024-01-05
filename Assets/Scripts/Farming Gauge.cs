using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FarmingGauge : MonoBehaviour
{
    public Slider gaugeSlider;

    private float gauge = 0f;


    public void EnemyDefeated()
    {
        float increaseAmount = 10f;

        gauge += increaseAmount;

        gauge = Mathf.Clamp(gauge, 0f, 100f);

        UpdateGaugeUI();
    }

    private void UpdateGaugeUI()
    {
        gaugeSlider.value = gauge;
    }

}
