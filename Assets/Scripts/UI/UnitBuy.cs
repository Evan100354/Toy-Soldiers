using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class UnitBuy : MonoBehaviour
{
    int chaffCount = 0, grenadierCount = 0;

    public int points;

    public TextMeshProUGUI chaffCountTag, grenadierCountTag, pointsTag;

    public SpawnTroops spawnTroops;

    public void BuyUnit(int unitID)
    {
        switch(unitID)
        {
            case 0:
                if (1 > points) break;
                points -= 1;
                chaffCount++; break;
            case 1:
                if (3 > points) break;
                points -= 3;
                grenadierCount++; break;
        }

        SetCounts();
    }

    public void SetCounts()
    {
        chaffCountTag.text = chaffCount.ToString();
        grenadierCountTag.text = grenadierCount.ToString();
        pointsTag.text = points.ToString();
    }

    private void Start()
    {
        SetCounts();
    }

    public void GameStart()
    {
        spawnTroops.chaffTroopCount = chaffCount;
        spawnTroops.grenadeTroopCount = grenadierCount;
        spawnTroops.flagTroopCount = 1;

        this.gameObject.SetActive(false);

        spawnTroops.gameObject.SetActive(true);

        spawnTroops.SetTroopCounters();
    }    
}
