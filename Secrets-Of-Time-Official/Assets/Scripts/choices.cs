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
    int Choice = -1; //-1 - Start Room (You can't go back there) 0 - 1950, 1 - 1980, 2 - 2000, 3 - 2017

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

    void Choose()//Obvious
    {
        if (!animation.isPlaying || animation.IsPlaying("time_machine_idle"))
        {
            if (!hidden)
            {
                Hide(TimeMachine);
                //animation["hide"].speed = -1;
                //animation.CrossFade("hide", 0.5f);
            }
            else
            {
                SetTimer(10);
            }
            Choice++;
            //too lazy to rewrite with switch, but this works I think
            if (Choice == 1) animation.CrossFade("choice1", 0.5f);
            if (Choice == 2) animation.CrossFade("choice2", 0.5f);
            if (Choice == 3) animation.CrossFade("choice3", 0.5f);
            if (Choice == 0) animation.CrossFade("choice4", 0.5f);
            if (Choice == Rooms.Length)
            {
                Choice = 0;
                animation.CrossFade("choice4", 0.5f);
            }
            //Debug.Log(Choice);
        }
    }

    void Teleportation(int _choice)//Obvious
    {
        if (!clicked[_choice])
        {
            animation.CrossFade("teleportation", 1f);
            for (int i = 0; i < clicked.Length; i++)
            {
                clicked[i] = false;//Equilibrium!!@!@!@!
            }
            SetTimer(10);           
            Player.transform.position = Rooms[_choice].transform.position;
            clicked[Choice] = true;
        }
    }

    void Awake()//Obvious
    {
        animation = TimeMachine.GetComponent<Animation>();
    }

    void Start()//Obvious
    {               
        //animation.CrossFade("hide", 0.2f);
        if (hidden)
        {
           Hide(TimeMachine);
        }
        
    }

    void Update()//Obvious
    {
        Timer -= Time.deltaTime;// Timer

        if (!hidden)
        {
            SetTimer(10);
        }

        if(Timer <= 0)
        {

            //animation.CrossFade("hide",0.5f);

            if (!animation.IsPlaying("hide"))
            {
                Hide(TimeMachine);

            }
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
            animation.CrossFade("time_machine_idle", 0.5f);
        }
        //Debug.Log(Math.Ceiling(Timer) + " secs");
    }
}

