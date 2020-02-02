using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapInteractables : MonoBehaviour
{
    private IsometricPlayer player;
    private SpriteRenderer m_SpriteRenderer;
    [SerializeField] Sprite highlightedSprite;
    private Sprite originalSprite;
    // Start is called before the first frame update
    void Awake()
    {
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        player = gameObject.GetComponent<IsometricPlayer>();
        originalSprite = m_SpriteRenderer.sprite;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("Player"))
            m_SpriteRenderer.sprite = highlightedSprite;
        //have it turn off the "highlighted" animation here
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("Player"))
            m_SpriteRenderer.sprite = originalSprite;
        //have it tur on the "highlighted" animation here
    }
}
