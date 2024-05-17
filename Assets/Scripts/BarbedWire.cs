using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarbedWire : MonoBehaviour, IExplodable
{
    private Collider2D collider2D;

    [SerializeField]
    private Sprite disabledSprite, chaffSprite, flagSprite, grenadeSprite;

    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        collider2D = GetComponent<Collider2D>();

        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<Unit>() != null)
        {
            collision.GetComponent<Unit>().BarbedWire(this);

            collider2D.isTrigger = false;
        }
    }

    public void Explode()
    {
        CutBarbedWire();
    }

    public void CutBarbedWire()
    {
        ChangeSprite(disabledSprite);
        collider2D.enabled = false;
    }

    public void Entangled(int unitID)
    {
        switch (unitID)
        {
            case 0:
                ChangeSprite(chaffSprite);
                break;
            case 1:
                ChangeSprite(grenadeSprite);
                break;
            case 2:
                ChangeSprite(flagSprite);
                break;
        }
    }

    private void ChangeSprite(Sprite sprite)
    {
        spriteRenderer.color = Color.gray;

        spriteRenderer.sprite = sprite;
    }
}
