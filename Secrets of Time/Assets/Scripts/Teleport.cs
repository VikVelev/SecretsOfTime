using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour {

    //Initializing variables
    public GameObject Player; 
    public GameObject TimeMachine; //Not yet used
    public GameObject[] Rooms; //All the rooms  
    public bool[] clicked; //Array that checks if you've clicked the room on the cube
    new Animation animation; //Animation component 
    int Choice = 0; //User Choice 0 means nothing not even the start position
    
    void Start() {

        animation = GetComponent<Animation>();
    }

    Vector3 GetPosition(GameObject _Object)
    {
        return _Object.transform.position;
    }

    void Choose()
    {
        if (Choice == 0)
        {
            //Otherwise searches for nonexistent Array index -1 
        }
        else if (clicked[Choice - 1]) //Checks if you have clicked the current choice, if you have , well you haven't.
        {
            clicked[Choice - 1] = false;
        }

        Choice++;
        animation.Play("choice");

        if (Choice == 6) //Loops
        {
            Choice = 1;
        }
        Debug.Log("Room " + Choice);
    }

    void Teleportation()
    {
        if (Choice == 0)
        { 
            //Otherwise searches for nonexistent Array index -1
        }
        else
        {
            if (!clicked[Choice - 1]) //If it isn't clicked, teleport
            {
                Player.transform.position = GetPosition(Rooms[Choice - 1]);
                clicked[Choice - 1] = true;
                Debug.Log("You are now in Room " + Choice);
                animation.Play("teleport");
            }
            else if (clicked[Choice - 1]) //If it is clicked, well no teleport for you.
            {
                Debug.Log("You are still in the same room");
            }
        }
    }

    void Update() {

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Teleportation();
        } 
        else if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            Choose();
        }
        if (animation.isPlaying == false)
        {
            animation.Play("idle");
        }

    }
}