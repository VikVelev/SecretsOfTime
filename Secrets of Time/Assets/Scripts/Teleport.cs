using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour {

    //Initializing variables
    public GameObject Player;
    public GameObject TimeMachine;
    public GameObject[] Rooms = new GameObject[4]; //All the rooms  
    public bool[] clicked = new bool[4]; //Array that checks if you've clicked the room on the cube
    new Animation animation;
    int Choice = 0; //User Choice 0 means start position
    bool Mouse0Pressed = false;
    Quaternion CurrentRotation;

    Vector3 GetPosition(GameObject _Object)//Obvious
    {
        return _Object.transform.position;
    }

    Quaternion GetRotation(GameObject _Object)
    {
        return _Object.transform.rotation;
    }

    void Choose()
    {
        if (clicked[Choice]) clicked[Choice] = false;//Checks if you have clicked the current choice, if you have , well you haven't.

        Choice++; 
          
        if (Choice == 5) //Loops
        {
            Choice = 0;
            StartCoroutine(RotateTimeMachine(Vector3.up * 90, 0.1f));
            TimeMachine.transform.rotation = Quaternion.Euler(0, 0, 0);
        } else
        {
            StartCoroutine(RotateTimeMachine(Vector3.up * 90, 0.1f));
        }
            
            Debug.Log(Choice);

            if (Mouse0Pressed) Mouse0Pressed = false;
    }

    void Teleportation()
    {
            if (!clicked[Choice]) //If it isn't clicked, teleport
            {
                CurrentRotation = GetRotation(TimeMachine);
                animation.Stop("idle");
                animation.Play("teleport");
                Player.transform.position = GetPosition(Rooms[Choice]);
                clicked[Choice] = true;
                Debug.Log("You are now in Room " + Choice);
            }

        if (!Mouse0Pressed) Mouse0Pressed = true;
    }

    IEnumerator RotateTimeMachine(Vector3 byAngles, float inTime) 
    {
        var fromAngle = GetRotation(TimeMachine);
        var toAngle = Quaternion.Euler(transform.eulerAngles + byAngles);
        for (var t = 0f; t < 1; t += Time.deltaTime / inTime)
        {
            transform.rotation = Quaternion.Slerp(fromAngle, toAngle, t);
            yield return null;
        }
    }

    void Start()
    {
        animation = GetComponent<Animation>();
        animation.Play("idle");
        clicked[0] = true; //You are in the first room.
        for (int i = 1; i < clicked.Length; i++) clicked[i] = false; //You are not in the rest of the rooms. idk if defaults are false.

    }

    void Update() {

        if (Input.GetKeyDown(KeyCode.Mouse0)) Teleportation();           
        if (Input.GetKeyDown(KeyCode.Mouse1)) Choose();
        if (Mouse0Pressed && !animation.isPlaying)
        {
                Debug.Log(CurrentRotation);
                TimeMachine.transform.rotation = CurrentRotation;
                Debug.Log("Rotation set to " + GetRotation(TimeMachine));
                animation.Play("idle");
        }
    }
}