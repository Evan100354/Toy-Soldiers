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
        if(tilemap.GetTile(tilepos) != null)
        {
            TileData tileData = dataFromTiles[tilemap.GetTile(tilepos)];

            if (tileData.destructible)
            {
                SetTile(tilepos, null);
            }


            //Switch the tile to the right to a slope
            if(tilemap.GetTile(new Vector3Int(tilepos.x + 1, tilepos.y, tilepos.z)) != null)
            {
                SetTile(new Vector3Int(tilepos.x + 1, tilepos.y, tilepos.z), tileData.slopeR);
            }

            //Switch the tile to the left to a slope
            if (tilemap.GetTile(new Vector3Int(tilepos.x - 1, tilepos.y, tilepos.z)) != null)
            {
                SetTile(new Vector3Int(tilepos.x - 1, tilepos.y, tilepos.z), tileData.slopeL);
            }
        }
    }

    public void SetTile(Vector3Int tilepos, TileBase tile)
    {
        tilemap.SetTile(tilepos, tile);
    }

}
