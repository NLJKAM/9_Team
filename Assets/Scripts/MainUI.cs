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
    public void ExitButton(GameObject panel)
    {
        panel.SetActive(false);
    }
    public void FarmingHuntButton(bool tendency)
    {
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

        farmingPanel.SetActive(false);
        Sword.instance.currentFarmingGauge = 0;
        Sword.instance.FarmingGaugeSet();
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
