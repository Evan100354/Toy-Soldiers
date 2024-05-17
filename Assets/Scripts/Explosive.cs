using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;
using UnityEngine.Tilemaps;

public class Explosive : MonoBehaviour ,IExplodable
{
    public int ExplosionRadius;

    public Tilemap ground;

    public MapManager mapManager;

    public SpriteRenderer spriteRenderer;

    public void Explode()
    {
        this.gameObject.SetActive(false);

        //Debug.Log("Explode");
        ground = GameObject.FindWithTag("Ground").GetComponent<Tilemap>();//Get the tilemap

        mapManager = GameObject.FindWithTag("MapManager").GetComponent<MapManager>();

        Vector2 pos = transform.position; //center of the circle

        for (int x = -ExplosionRadius; x < ExplosionRadius; x++)
        {
            for (int y = -ExplosionRadius; y < ExplosionRadius; y++) //find the box
            {
                Vector3Int Tilepos = ground.WorldToCell(new Vector2(pos.x + x, pos.y + y));
                if (Vector3.Distance(pos, Tilepos) <= ExplosionRadius) //check distance to make it a circle
                {
                    mapManager.ExplodeTile(Tilepos);
                }
            }
        }

        //Checks all items in blast radius
        Collider2D[] collider2Ds = Physics2D.OverlapCircleAll(this.transform.position, ExplosionRadius);

        foreach (Collider2D collider in collider2Ds) 
        { 
            GameObject gameObject = collider.gameObject;
            // If the object has an explodable component, it will explode
            if (gameObject.GetComponent<IExplodable>() != null) 
            {
                gameObject.GetComponent<IExplodable>().Explode();
            }
        }
    }
}
