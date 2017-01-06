using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour {

    //Initializing variables
    public GameObject Player;
    public GameObject TimeMachine;
    public GameObject[] Rooms = new GameObject[5]; //All the rooms  
    public bool[] clicked = new bool[5]; //Array that checks if you've clicked the room on the cube
    new Animation animation;
    int Choice = 0; //User Choice 0 means start position
    bool Mouse0Pressed = false;
    bool isUp = false;

    Vector3 GetPosition(GameObject _Object)//Obvious
    {
        return _Object.transform.position;
    }

    Quaternion GetRotation(GameObject _Object)//Obvious
    {
        return _Object.transform.rotation;
    }

    void NextChoice()
    {
        Choice++; //Next Choice
       
        if (Choice == 5) //Loops if no more choices
        {
            Choice = 0;
            CheckChoiceAnim();
            TimeMachine.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            CheckChoiceAnim();
        }
            
    }

    void CheckChoiceAnim()
    {
        animation.Stop();
        if (Choice == 0)
        {
            animation.Play("choiceHome");
            isUp = true;
        }
        if (Choice == 1 && isUp)
        {
            animation.Play("choiceFix");
            isUp = false;
            
        } else if (Choice == 1) animation.Play("choice1");
        if (Choice == 2) animation.Play("choice2");
        if (Choice == 3) animation.Play("choice3");
        if (Choice == 4) animation.Play("choice4");

    }

    void Choose()
    {
            if (clicked[Choice]) clicked[Choice] = false;//Checks if you have clicked the current choice, if you have , well you haven't.           
            NextChoice();
            Debug.Log(Choice);
            if (Mouse0Pressed) Mouse0Pressed = false;
    }

    void Teleportation()
    {
            if (!clicked[Choice]) //If it isn't clicked, teleport
            {
                animation.Stop("idle");
                animation.Play("teleport");
                Player.transform.position = GetPosition(Rooms[Choice]);
                clicked[Choice] = true;
                Debug.Log("You are now in Room " + Choice);
            }

        if (!Mouse0Pressed) Mouse0Pressed = true;
    }
    void Start()
    {
        animation = GetComponent<Animation>();
        clicked[0] = true; //You are in the first room.
        for (int i = 1; i < clicked.Length; i++) clicked[i] = false; //You are not in the rest of the rooms. idk if defaults are false.
    }

    void Update() {

        if (Input.GetKeyDown(KeyCode.Mouse0)) Teleportation();
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            Choose();
        }
        if (!animation.isPlaying)
        {
               animation.Play("idle");
        }
    }
}