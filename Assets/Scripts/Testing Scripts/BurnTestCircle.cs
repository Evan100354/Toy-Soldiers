using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurnTestCircle : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<IBurnable>() != null)
        {
            collision.gameObject.GetComponent<IBurnable>().isBurning = true;
        }
    }
}
