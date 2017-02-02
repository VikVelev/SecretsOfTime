using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class choices : MonoBehaviour {

    public GameObject Player;
    public GameObject TimeMachine;
    public GameObject[] Rooms = new GameObject[4]; //All the rooms  
    public bool[] clicked = new bool[4]; //Array that checks if you've clicked the room on the cube
    new Animation animation;
    public float Timer = 0;
    bool hidden = true;
    int Choice = -1; //0 - 1950, 1 - 1980, 2 - 2000, 3 - 2017

    public Vector3 GetPosition(GameObject _Object)//Obvious
    {
        return _Object.transform.position;
    }

    public Quaternion GetRotation(GameObject _Object)//Obvious
    {
        return _Object.transform.rotation;
    }
    
    void SetTimer(float _num)//Obvious
    {
        Timer = _num;
    }

    public void Hide(GameObject object_)//Obvious
    {
        object_.SetActive(Toggle(hidden));
        hidden = Toggle(hidden);
    }

    public bool Toggle(bool _toggle)//Obvious
    {
        if (!_toggle)
        {
            _toggle = true;
        }
        else
        {
            _toggle = false;
        }
        return _toggle;
    }

    void Choose()
    {
        if (!animation.isPlaying || animation.IsPlaying("time_machine_idle"))
        {
            if (!hidden)
            {
                Hide(TimeMachine);
            }
            else
            {
                SetTimer(10);
            }
            Choice++;
            //too lazy to rewrite with switch
            if (Choice == 1) animation.Play("choice1");
            if (Choice == 2) animation.Play("choice2");
            if (Choice == 3) animation.Play("choice3");
            if (Choice == 0) animation.Play("choice4"); //0 animaciq trqbva da preminava 2017-1950.
            if (Choice == 4)
            {
                Choice = 0;
            }
            Debug.Log(Choice);
        }
    }

    void Teleportation(int _choice)
    {
        SetTimer(10);
        animation.Play("teleportation");
        Player.transform.position = Rooms[_choice].transform.position;
        clicked[_choice] = true;
        //TODO: THIS IS NOT WORKING AT ALL
            if (Choice != 0)
            {
                TimeMachine.transform.Rotate(0, Choice * 90, 0);
                Debug.Log("1234123");
            } else
            {
                TimeMachine.transform.Rotate(0, 90, 0);
                Debug.Log("1234123");
            }
        //end TODO
    }

    void Start()
    {
        if (hidden)
        {
            Hide(TimeMachine);
        }
        animation = TimeMachine.GetComponent<Animation>();
        clicked[0] = true; //You are in the first room.
    }

    void Update()
    {
        Timer -= Time.deltaTime;// Timer

        if (!hidden)
        {
            SetTimer(10);
        }

        if(Timer <= 0)
        {
            Hide(TimeMachine);
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Teleportation(Choice);
        }
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            Choose();
        }
        if (!animation.isPlaying)
        {
            animation.Play("time_machine_idle");
        }
        Debug.Log(Math.Ceiling(Timer));
    }
}

