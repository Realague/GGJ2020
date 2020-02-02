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
    private bool notMoving;
    private enum MoveDirection
    {
        N,
        S,
        E,
        W,
        NE,
        SE,
        NW,
        SW, 
        nothing
    }
    private enum StaticDirection
    {
        N,
        S,
        E,
        W,
        NE,
        SE,
        NW,
        SW,
        nothing
    }

    private StaticDirection StaticDirectionFacing;
    private MoveDirection MoveDirectionFacing;
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
        
        ChooseDirection();
        isMoving();
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

    private void isMoving()
    {
        if(rb.velocity.magnitude < 0.01)
        {
            notMoving = true;
            MoveDirectionFacing = MoveDirection.nothing;
        }
        else
    
            notMoving = false;
            StaticDirectionFacing = StaticDirection.nothing;
    }

    private void ChooseDirection()
    {
        if(rb.velocity.x < 0 && rb.velocity.y == 0)
        {
            MoveDirectionFacing = MoveDirection.W;
            StaticDirectionFacing = StaticDirection.W;
        }
        else if(rb.velocity.x < 0 && rb.velocity.y > 0)
        {
            MoveDirectionFacing = MoveDirection.NW;
            StaticDirectionFacing = StaticDirection.NW;
        }
        else if(rb.velocity.x < 0 && rb.velocity.y < 0)
        {
            MoveDirectionFacing = MoveDirection.SW;
            StaticDirectionFacing = StaticDirection.SW;
        }
        else if(rb.velocity.x == 0 && rb.velocity.y > 0)
        {
            MoveDirectionFacing = MoveDirection.N;
            StaticDirectionFacing = StaticDirection.N;
        }
        else if(rb.velocity.x == 0 && rb.velocity.y < 0)
        {
            MoveDirectionFacing = MoveDirection.S;
            StaticDirectionFacing = StaticDirection.S;
        }
        else if(rb.velocity.x > 0 && rb.velocity.y == 0)
        {
            MoveDirectionFacing = MoveDirection.E;
            StaticDirectionFacing = StaticDirection.E;
        }
        else if(rb.velocity.x > 0 && rb.velocity.y > 0)
        {
            MoveDirectionFacing = MoveDirection.NE;
            StaticDirectionFacing = StaticDirection.NE;
        }
        else if(rb.velocity.x  > 0 && rb.velocity.y < 0)
        {
            MoveDirectionFacing = MoveDirection.SE;
            StaticDirectionFacing = StaticDirection.SE;
        }

    //use the notmoving variable to decide whether we should use moving or stattic animations after this

    }
}
