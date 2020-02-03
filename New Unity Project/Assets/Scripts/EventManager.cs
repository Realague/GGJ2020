using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;



public class EventManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }


    void activateState2()
    {
        GameObject.Find("ActivateState2").SetActive(true);
    }

    void activateTrees()
    {
        GameObject.Find("Grid/Trees").GetComponent<TilemapRenderer>().enabled = true;
        
    }

    void removeTrees()
    {
        GameObject.Find("Grid/Trees").GetComponent<TilemapRenderer>().enabled = false; 
    }

    void activatePigs()
    {
        GameObject.Find("Grid/Pigs").GetComponent<TilemapRenderer>().enabled = true;

    }

    void removePigs()
    {
        GameObject.Find("Grid/Pigs").GetComponent<TilemapRenderer>().enabled = false;

    }

    void activateCities()
    {
        GameObject.Find("Grid/Cities").GetComponent<TilemapRenderer>().enabled = true;

    }

    void removeCities()
    {
        GameObject.Find("Grid/Cities").GetComponent<TilemapRenderer>().enabled = false;

    }

    void activateVillages()
    {
        GameObject.Find("Grid/Villages").GetComponent<TilemapRenderer>().enabled = true;

    }

    void removeVillages()
    {
        GameObject.Find("Grid/Villages").GetComponent<TilemapRenderer>().enabled = false;

    }

    void activateRobots()
    {
        GameObject.Find("Grid/Robots").GetComponent<TilemapRenderer>().enabled = true;

    }

    void removeRobots()
    {
        GameObject.Find("Grid/Robots").GetComponent<TilemapRenderer>().enabled = false;

    }

    void activateHumans()
    {
        GameObject.Find("Grid/Humans").GetComponent<TilemapRenderer>().enabled = true;

    }

    void removeHumans()
    {
        GameObject.Find("Grid/Humans").GetComponent<TilemapRenderer>().enabled = false;

    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
