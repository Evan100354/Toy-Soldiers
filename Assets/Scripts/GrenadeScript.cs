using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GrenadeScript : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        this.GetComponent<Explosive>().Explode();
    }
}
