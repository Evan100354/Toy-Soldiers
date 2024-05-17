using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandMineScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<Unit>() != null)
        {
            Debug.Log("Landmine triggered");
            this.gameObject.GetComponent<IExplodable>().Explode();
        }
    }
}
