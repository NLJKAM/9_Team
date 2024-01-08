using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainUI : MonoBehaviour
{
    public GameObject farmingPanel;
    public GameObject farmingWarningPanel;
    public GameObject informationPanel;
    public Text informationText;
    public Inventory inventory;
    public EnhancementSystem enhancementSystem;
    public void ExitButton(GameObject panel)
    {
        panel.SetActive(false);
    }
    public void FarmingHuntButton(bool tendency)
    {
        int percent = 0;
        percent = Random.RandomRange(1, 101);
        if (tendency)//선한놈
        {
            Sword.instance.holyTendency++;
            //선한 선택지 보상

        }
        else//악한놈
        {
            Sword.instance.evilTendency++;
            //악한 선택지 보상

        }
        //공동 보상일시 여기다 추가
        RandomCompensation(percent);


        farmingPanel.SetActive(false);
        Sword.instance.currentFarmingGauge = 0;
        Sword.instance.FarmingGaugeSet();
    }
    private void RandomCompensation(int percent)
    {
        inventory.AddItem(1, Random.RandomRange(1, 10));
        if (1<= percent&& percent < 50)
        {
            inventory.AddItem(2);
        }
        else if (50<=percent && percent < 90)
        {
            inventory.AddItem(3);
        }
        else if (90<= percent && percent < 101)
        {
            inventory.AddItem(4);
        }
    }
    public void FarmingButton()
    {
        if(Sword.instance.currentFarmingGauge >= Sword.instance.MaxFarmingGauge)
        {
            farmingPanel.SetActive(true);
        }
        else
        {
            farmingWarningPanel.SetActive(true);
        }
    }
    public void InformationPanel()
    {
        informationPanel.SetActive(true);
        informationText.text = $"데미지 : {Sword.instance.damage}\n" +
            $"공격속도 : 한대당 {Sword.instance.attackSpeed}초\n" +
            $"체력 : {Sword.instance.swordHP}\n" +
            $"악 성향 : {Sword.instance.evilTendency}\n" +
            $"선 성향 : {Sword.instance.holyTendency}";
    }
}
