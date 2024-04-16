using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GibDestroyer : MonoBehaviour
{
    private bool isDestroying = false;

    private void Update()
    {
        if (!isDestroying)
        {
            isDestroying = true;

            Invoke("DestroyGib", 5f);
        }
    }

    public void DestroyGib()
    {
        Destroy(gameObject);
    }
}
