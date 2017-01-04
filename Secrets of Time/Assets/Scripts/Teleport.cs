using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour {

    public GameObject Player;
    public GameObject TimeMachine;
    public GameObject[] Rooms;
    public bool[] clicked;
    int Choice = 0;   
    
    void Start() {

        
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (Choice == 0)
            { }
            else
            {
                if (!clicked[Choice - 1])
                {
                    Player.transform.position = Rooms[Choice - 1].transform.position;
                    clicked[Choice - 1] = true;
                    Debug.Log("You are now in Room " + Choice);
                }
                else if (clicked[Choice - 1])
                {
                    Debug.Log("You are still in the same room");
                }
            }
        } 
        else if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            if(Choice == 0)
            { }
            else if (clicked[Choice - 1])
            {
                clicked[Choice - 1] = false;
            }

            Choice++;
                      
            if (Choice == 6)
            { 
                Choice = 1;
            }

            Debug.Log("Room " + Choice);

        }
    }
}

