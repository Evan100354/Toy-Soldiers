using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTroops : MonoBehaviour
{
    public GameObject spawnTroop;

    public Transform spawnTroopPosition;

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Spawn");

            Instantiate(spawnTroop, spawnTroopPosition);
        }
    }
}
