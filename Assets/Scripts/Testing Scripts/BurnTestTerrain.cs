using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurnTestTerrain : MonoBehaviour, IBurnable
{
    private bool canSpread = true;
    public bool isBurning {  get; set; }

    SpriteRenderer spriteRenderer;

    public List<GameObject> objectsInTrigger = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        if(isBurning)
            Burn();
    }

    public void Burn()
    {
        spriteRenderer.color = Color.red;

        if(canSpread )
        {
            Spread();

            Invoke("ResetCanSpread", 2f);

            canSpread = false;
        }
    }

    public void Spread()
    {
        foreach(GameObject obj in objectsInTrigger)
        {
            int i = Random.Range(0, 6);
            Debug.Log(i);
            if(i == 1)
            {
                Debug.Log(obj);
                obj.GetComponent<IBurnable>().isBurning = true;
            }
        }
    }

    private void ResetCanSpread()
    {
        canSpread = true;
    }
}
