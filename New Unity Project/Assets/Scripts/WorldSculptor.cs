using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


public class WorldSculptor : MonoBehaviour
{
    public Tilemap tilemap;
    public Tile yellowTile;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(tilemap.size);
    }

    // Update is called once per frame
    void Update()
    {
        // Changing 0,0 tile to yellow
        // public void SetTile(Vector3Int position, Tilemaps.TileBase tile);
        
    }

    void ChangeTile(Vector3Int coordinate, Tile newTile)
    {
        tilemap.SetTile(coordinate, newTile);
    }

    void DeleteTile(Vector3Int coordinate, Tile newTile)
    {
        tilemap.SetTile(coordinate, null);
    }
}
