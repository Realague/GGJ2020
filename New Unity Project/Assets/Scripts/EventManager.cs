using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }


    void ExecuteEvent(string eventName) // user calls event A over B
    {
        switch (eventName)
        {
            case "event1":
                event1();
                break;
            default:
                Debug.Log("Invalid Event Called");
                break;

        }
    }


    void event1()
    {
        // worldSculptor.create(0, 0, 0, trees);
    }

    void StartingEvent()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
