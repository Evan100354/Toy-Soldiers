using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapManager : MonoBehaviour
{
    [SerializeField]
    Tilemap tilemap;

    
    [SerializeField]
    private List<TileData> tileDatas;

    
    private Dictionary<TileBase, TileData> dataFromTiles;

    private void Awake()
    {
        dataFromTiles = new Dictionary<TileBase, TileData>();

        foreach (var tileData in tileDatas)
        {
            foreach (var tile in tileData.tiles)
            {
                dataFromTiles.Add(tile, tileData);
            }
        }
    }
    

    public void ExplodeTile(Vector3Int tilepos)
    {
        Debug.Log(tilemap.GetTile(tilepos));
        if(tilemap.GetTile(tilepos) != null)
        {
            TileData tileData = dataFromTiles[tilemap.GetTile(tilepos)];

            if (tileData.destructible)
            {
                SetTile(tilepos, null);
            }
        }
    }

    public void SetTile(Vector3Int tilepos, TileBase tile)
    {
        tilemap.SetTile(tilepos, tile);
    }

}
