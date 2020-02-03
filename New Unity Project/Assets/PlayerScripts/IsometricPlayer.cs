using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsometricPlayer : MonoBehaviour
{
    public List<Rect> mapBorders;
    public float moveSpeed;
    [SerializeField] private GameObject interactableObj = null;
    public Tree tree;
    public Cow cow;
    public Building building;
    private Rigidbody2D rb;
    private bool canInteract = false;
    private bool notMoving;

    public GameObject treeLayer;
    public GameObject cityLayer;
    public GameObject fenceLayer;
    public GameObject villageLayer;

    public GameObject state2;
    public GameObject state3;
    public GameObject state4;
    public GameObject stateEnding;
    private bool flag = false;
    public GameObject gameOverScreen;

    private float timeMax = 20f;
    private float screenTimer = 40f;
    private float copy = 0f;
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
        copy = timeMax;
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
        rb.MovePosition(newPos);
    }

    void Update()
    {
        copy -= Time.deltaTime;
        if (copy <= 0)
        {
            if (interactableObj != null && interactableObj.name == "Tree")
            {
                if (canInteract && Input.GetKeyDown(KeyCode.E))
                {
                    if (interactableObj.name == "Tree")
                    {
                        Debug.Log("tree");
                        tree.gameObject.SetActive(false);
                        if (copy <= 0)
                        {
                            treeLayer.gameObject.SetActive(true);
                            cow.gameObject.SetActive(true);
                            state2.SetActive(true);
                            copy = timeMax;
                        }

                    }
                }
            }
            else if (interactableObj != null && interactableObj.name == "Cow")
            {

                if (canInteract && Input.GetKeyDown(KeyCode.E))
                {

                    if (interactableObj.name == "Cow")
                    {
                        Debug.Log("cow");
                        cow.gameObject.SetActive(false);
                        if (copy <= 0)
                        { 
                            fenceLayer.gameObject.SetActive(true);
                            villageLayer.gameObject.SetActive(true);
                            building.gameObject.SetActive(true);
                            state3.SetActive(true);
                            copy = timeMax;
                        }

                    }
                }
            }
            else if (interactableObj != null && interactableObj.name == "Building")
            {
                Debug.Log("here");
                if (canInteract && Input.GetKeyDown(KeyCode.E))
                {
                    Debug.Log("Here2");
                    if (interactableObj.name == "Building")
                    {
                        Debug.Log("building");
                        building.gameObject.SetActive(false);
                        if (copy <= 0)
                        {
                            cityLayer.gameObject.SetActive(true);
                            villageLayer.gameObject.SetActive(false);
                            fenceLayer.gameObject.SetActive(false);
                            treeLayer.gameObject.SetActive(false);
                            state4.SetActive(true);
                            flag = true;
                        }
                    }
                }
            }

            if(flag)
            {
                screenTimer -= Time.deltaTime;
                if (screenTimer <= 0)
                    gameOverScreen.gameObject.SetActive(true);
            }
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
            interactableObj = col.gameObject;
        }
        else if(col.gameObject.CompareTag("Cow"))
        {
            //Debug.Log("here");
            canInteract = true;
            interactableObj = col.gameObject;
        }
        else if(col.gameObject.CompareTag("Building"))
        {
            //Debug.Log("here");
            canInteract = true;
            interactableObj = col.gameObject;
        }
    }
    
    void OnTriggerExit2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("Option"))
        {
            canInteract = false;
            interactableObj = null;
        }
        else if(col.gameObject.CompareTag("Cow"))
        {
            canInteract = false;
            interactableObj = null;
        }
        if(col.gameObject.CompareTag("Building"))
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
