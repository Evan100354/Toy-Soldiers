using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerExplosion : MonoBehaviour
{
    public GameObject explosion;

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Grenade")
        {
            explosion.SetActive(true);
        }
    }
}
