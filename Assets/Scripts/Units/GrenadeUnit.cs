using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeUnit : Unit
{
    public GameObject grenadePrefab;

    public float launchForce;

    public override void Die()
    {
        GameObject grenade = Instantiate(grenadePrefab, this.transform.position, Quaternion.identity);

        grenade.GetComponent<Rigidbody2D>().AddForce(Vector2.right * launchForce + Vector2.up * launchForce, ForceMode2D.Impulse);

        Destroy(gameObject);
    }
}
