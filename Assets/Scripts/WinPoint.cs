using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinPoint : MonoBehaviour
{
    public GameObject winText;
    public Rigidbody2D flagBearerRb;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.GetComponent<FlagUnit>())
        {
            Debug.Log("YIPPEEEEEEEEEEE");
            flagBearerRb.isKinematic = true;
            winText.SetActive(true);
        }
    }
}
