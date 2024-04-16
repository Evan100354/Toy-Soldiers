using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurnTestTerrain : MonoBehaviour, IBurnable
{
    public bool canSpread = false;
    public bool isBurning {  get; set; }
    public bool isCatchingFire { get; set; }

    public float spreadRadius = 0.5f;

    SpriteRenderer spriteRenderer;

    private ContactFilter2D contactFilter;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        contactFilter.NoFilter();
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
        if (canSpread)
        {
            Debug.Log("Spreading from " + this.name );
            canSpread = false;

            Collider2D[] collider2Ds = new Collider2D[30];
            Physics2D.OverlapCircle(this.transform.position, spreadRadius, contactFilter ,collider2Ds);

            foreach(Collider2D col in collider2Ds)
            {
                if (col != null)
                {
                    GameObject gameObject = col.gameObject;
                    IBurnable burnable = gameObject.GetComponent<IBurnable>();

                    if (burnable != null)
                    {
                        if(!burnable.isCatchingFire && !burnable.isBurning)
                        {
                            //Debug.Log("Calling from " + this.gameObject.name);
                            burnable.isCatchingFire = true;
                            burnable.CatchFire(false);
                        }
                    }
                }
            }

            float f = Random.Range(1f, 3f);

            Invoke("ResetCanSpread", f);
        }
    }

    public void CatchFire(bool g)
    {
        if (!g)
        {
            int i = Random.Range(0, 5);
            //Debug.Log(i + " " + this.gameObject.name);
            if (i == 0)
            {
                isBurning = true;

                float f = Random.Range(1f, 3f);

                Invoke("ResetCanSpread", f);
            }
            else
            {
                isCatchingFire = false;
            }
        }
        else
        {
            canSpread = true;
            isBurning = true;
        }
    }

    private void ResetCanSpread()
    {
        canSpread = true;
    }
}
