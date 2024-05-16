using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTroops : MonoBehaviour
{
    public GameObject[] troops;

    public Transform spawnTroopPosition;

    public void SpawnTroop(int  spawnTroopId)
    {
        Instantiate(troops[spawnTroopId], spawnTroopPosition);
    }
}
