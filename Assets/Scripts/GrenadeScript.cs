using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GrenadeScript : MonoBehaviour
{
    public GameObject explosionEffect;
    public Transform grenadePos;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        explosionEffect.SetActive(true);
        this.GetComponent<Explosive>().Explode();        
    }
}
