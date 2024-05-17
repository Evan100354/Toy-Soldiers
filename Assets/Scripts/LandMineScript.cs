using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandMineScript : MonoBehaviour
{
    public GameObject explosionEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<EngineerUnit>() != null)
        {
            collision.GetComponent<EngineerUnit>().RemoveLandMine(this);
            return;
        }

        if (collision.GetComponent<Unit>() != null)
        {
            Debug.Log("Landmine triggered");
            this.gameObject.GetComponent<IExplodable>().Explode();
        }

        explosionEffect.SetActive(true);
    }

    public void TriggerDisable()
    {
        Invoke("Disabled", 2.5f);
    }

    private void Disabled()
    {
        this.gameObject.SetActive(false);
    }
}
