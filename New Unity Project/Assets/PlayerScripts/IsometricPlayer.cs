using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsometricPlayer : MonoBehaviour
{
    public List<Rect> mapBorders;
    public float moveSpeed;
    private MapInteractables interactableObj = null;
    private Rigidbody2D rb;
    private bool canInteract = false;
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 currentPosition = rb.position;
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector2 inputVector = new Vector2(horizontal, vertical);
        inputVector = Vector2.ClampMagnitude(inputVector, 1);
        Vector2 movement = inputVector * moveSpeed;
        Vector2 newPos = currentPosition + movement * Time.fixedDeltaTime;
        mapBorders.ForEach(delegate (Rect mapBorder)
        {
            if (mapBorder.Contains(newPos))
            {
                rb.MovePosition(newPos);
                return;
            }
        });
    }

    void Update()
    {
        if(interactableObj != null)
        {
            if(canInteract && Input.GetKey(KeyCode.E))
                ExecuteEvent(interactableObj.gameObject.name);
        }

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        //Debug.Log("here");
        if(col.gameObject.CompareTag("Option"))
        {
            //Debug.Log("here");
            canInteract = true;
            interactableObj = col.gameObject.GetComponent<MapInteractables>();
        }
    }
    
    void OnTriggerExit2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("Option"))
        {
            canInteract = false;
            interactableObj = null;
        }
    }

    private void ExecuteEvent(string name)
    {
        //connects to specific fuctions depending on which object has been interacted with
    }
}
