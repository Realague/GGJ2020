using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapInteractables : MonoBehaviour
{
    public IsometricPlayer player;
    public Cow cow;
    private SpriteRenderer m_SpriteRenderer;
    // Start is called before the first frame update
    void Awake()
    {
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
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
