using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "TileData")]
public class TileData : ScriptableObject
{
    public bool destructible = false;

    public TileBase[] tiles;

    public TileBase slopeR;

    public TileBase slopeL;
}