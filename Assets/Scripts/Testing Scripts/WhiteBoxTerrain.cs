using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteBoxTerrain : MonoBehaviour , IExplodable
{
    public ParticleSystem ps;

    public void Start()
    {
    }

    public void Explode()
    {
        Transform transform = this.transform;

        ParticleSystem particleSystem = Instantiate(ps, transform.transform.position, transform.rotation);

        particleSystem.Play();
        Destroy(gameObject);
    }
}
