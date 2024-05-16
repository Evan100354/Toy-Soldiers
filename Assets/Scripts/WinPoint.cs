using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinPoint : MonoBehaviour
{
    public GameObject winText;
    public Rigidbody2D flagBearerRb;

    FlagUnit flagUnit;
    public Animator anim;

    // Start is called before the first frame update
    private void Start()
    {
        flagUnit = GameObject.FindGameObjectWithTag("FlagUnit").GetComponent<FlagUnit>();
        
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.GetComponent<FlagUnit>())
        {
            Debug.Log("YIPPEEEEEEEEEEE");
            flagBearerRb.isKinematic = true;
            winText.SetActive(true);

            flagUnit.speed = 0;
            anim.speed = 0;
        }
    }
}
