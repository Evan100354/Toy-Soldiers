using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SpawnTroops : MonoBehaviour
{
    public GameObject[] troops;

    public Transform spawnTroopPosition;

    public float spawnDelay;

    private bool canSpawn = true;

    public int chaffTroopCount, flagTroopCount, grenadeTroopCount;

    public TextMeshProUGUI chaffTroopCountTag, flagTroopCountTag, grenadeTroopCountTag;

    public void SpawnTroop(int spawnTroopId)
    {
        if (!canSpawn) return;

        canSpawn = false;

        switch(spawnTroopId)
        {
            case 0:
                if (chaffTroopCount <= 0) break;
                Instantiate(troops[spawnTroopId], spawnTroopPosition);
                chaffTroopCount--;
                break;
            case 1:
                if (grenadeTroopCount <= 0) break;
                Instantiate(troops[spawnTroopId], spawnTroopPosition);
                grenadeTroopCount--;
                break;
            case 2:
                if (flagTroopCount <= 0) break;
                Instantiate(troops[spawnTroopId], spawnTroopPosition);
                flagTroopCount--;
                break;
        }

        

        Invoke("ResetCanSpawn", spawnDelay);

        SetTroopCounters();
    }

    void ResetCanSpawn()
    {
        canSpawn=true;
    }

    public void SetTroopCounters()
    {
        chaffTroopCountTag.text = chaffTroopCount.ToString();
        flagTroopCountTag.text = flagTroopCount.ToString();
        grenadeTroopCountTag.text = grenadeTroopCount.ToString();
    }

    private void Start()
    {
        SetTroopCounters();
    }
}
