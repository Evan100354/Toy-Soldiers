using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class UnitBuy : MonoBehaviour
{
    int chaffCount = 0, grenadierCount = 0, engineerCount = 0;

    public int points;

    public TextMeshProUGUI chaffCountTag, grenadierCountTag, engineerCountTag, pointsTag;

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
            case 3:
                if (3 > points) break;
                points -= 5;
                engineerCount++; break;
        }

        SetCounts();
    }

    public void SellUnit(int unitID)
    {
        switch (unitID)
        {
            case 0:
                if (chaffCount == 0) break;
                points += 1;
                chaffCount--; break;
            case 1:
                if (grenadierCount == 0) break;
                points += 3;
                chaffCount++; break;
            case 3:
                if (engineerCount == 0) break;
                points += 5;
                engineerCount++; break;
        }

        SetCounts();
    }

    public void SetCounts()
    {
        chaffCountTag.text = chaffCount.ToString();
        grenadierCountTag.text = grenadierCount.ToString();
        engineerCountTag.text = engineerCount.ToString();
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
        spawnTroops.engineerTroopCount = engineerCount;
        spawnTroops.flagTroopCount = 1;

        this.gameObject.SetActive(false);

        spawnTroops.gameObject.SetActive(true);

        spawnTroops.SetTroopCounters();
    }    
}
