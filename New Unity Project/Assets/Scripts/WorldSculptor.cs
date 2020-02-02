using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


public class WorldSculptor : MonoBehaviour
{
    public Tilemap tilemap;
    public TileBase greenTile;
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

    TileBase ChooseTile(string name)
    {
        switch (name)
        {
            case "green":
                return greenTile;
                break;
            default:
                Debug.Log("Invalid Tile Chosen");
                break;
        }
        return null;
    }

    void ChangeTile(Vector3Int coordinate, string name)
    {
        var newTile = ChooseTile(name);

        tilemap.SetTile(coordinate, newTile);
    }

    void DeleteTile(Vector3Int coordinate, string name)
    {
    }

    void ChangeTiles(Vector3Int coordinates, string name)
    {
    }
}
