using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HotbarControl : MonoBehaviour
{
    int hotbarIndex = 0;

    [Header("Hotbars")]
    public GameObject Hotbar1;
    public GameObject Hotbar2;
    public GameObject Hotbar3;
    public GameObject Hotbar4;

    [Header("Troopers")]
    public GameObject spawnTroopFlag;
    public GameObject spawnTroopChaff;
    public GameObject spawnTroopGrenadier;
    //public GameObject spawnTroop4;

    [Header("Spawn Location(s)")]
    public Transform spawnTroopPosition1;

    void Update()
    {
        if (Input.GetKeyDown("1"))
        {
            hotbarIndex = 1;
            Hotbar1.SetActive(false);
            Hotbar2.SetActive(true);
            Hotbar3.SetActive(true);
            Hotbar4.SetActive(true);
        }
        if (Input.GetKeyDown("2"))
        {
            hotbarIndex = 2;
            Hotbar2.SetActive(false);
            Hotbar1.SetActive(true);
            Hotbar3.SetActive(true);
            Hotbar4.SetActive(true);
        }
        if (Input.GetKeyDown("3"))
        {
            hotbarIndex = 3;
            Hotbar3.SetActive(false);
            Hotbar2.SetActive(true);
            Hotbar1.SetActive(true);
            Hotbar4.SetActive(true);
        }
        if (Input.GetKeyDown("4"))
        {
            hotbarIndex = 4;
            Hotbar4.SetActive(false);
            Hotbar2.SetActive(true);
            Hotbar3.SetActive(true);
            Hotbar1.SetActive(true);
        }

        switch (hotbarIndex)
        {
            case 1:
                if (Input.GetKeyDown("e"))
                {
                    Debug.Log("Unit 1 Spawned");
                    Instantiate(spawnTroopFlag, spawnTroopPosition1);
                }
                break;
            case 2:
                if (Input.GetKeyDown("e"))
                {
                    Debug.Log("Unit 2 Spawned");
                    Instantiate(spawnTroopChaff, spawnTroopPosition1);
                }
                break;
            case 3:
                if (Input.GetKeyDown("e"))
                {
                    Debug.Log("Unit 3 Spawned");
                    Instantiate(spawnTroopGrenadier, spawnTroopPosition1);
                }
                break;
            case 4:
                if (Input.GetKeyDown("e"))
                {
                    Debug.Log("Unit 4 Spawned");
                }
                break;
        }
    }
}
