using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour, IExplodable
{
    public float speed;

    public float gibForce = 2f;

    [SerializeField]
    public GameObject[] gibs;

    public bool dead = false;

    public int unitID;

    // Update is called once per frame
    void Update()
    {
        MoveForward();
    }

    public void Explode()
    {
        if (dead) return;

        for (int i = 0; i < gibs.Length; i++)
        {
            Vector2 direction = new Vector2((float)Random.Range(-3, 3), (float)Random.Range(0, 3));

            GameObject gib = Instantiate(gibs[i], transform.position, transform.rotation);

            gib.GetComponent<Rigidbody2D>().AddForce(direction * gibForce);
        }

        Die();
    }

    public virtual void MoveForward()
    {
        transform.position += transform.right * speed * Time.deltaTime;
    }

    public virtual void Die()
    {
        if (dead) return;

        dead = true;

        Destroy(gameObject);
    }

    public virtual void BarbedWire(BarbedWire barbedWire)
    {
        barbedWire.Entangled(unitID);

        Die();
    }
}
