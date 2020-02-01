using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapInteractables : MonoBehaviour
{
    private IsometricPlayer player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        //have it turn off the "highlighted" animation here
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        //have it tur on the "highlighted" animation here
    }
}
