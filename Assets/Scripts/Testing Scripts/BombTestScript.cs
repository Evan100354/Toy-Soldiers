using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombTestScript : MonoBehaviour
{
    private List<GameObject> objectsInTrigger = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        Invoke("Detonate", 3f);
    }

    public void Detonate ()
    {
        for(int i = objectsInTrigger.Count - 1; i >= 0; i--)
        {
            GameObject obj = objectsInTrigger[i];
            objectsInTrigger.Remove(obj);
            obj.GetComponent<IExplodable>().Explode();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<IExplodable>() != null)
        {
            objectsInTrigger.Add(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<IExplodable>() != null)
        {
            objectsInTrigger.Remove(collision.gameObject);
        }
    }
}
