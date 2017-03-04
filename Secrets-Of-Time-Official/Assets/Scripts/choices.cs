using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class choices : MonoBehaviour {

    public GameObject Player;
    public GameObject TimeMachine;
    public GameObject[] Rooms = new GameObject[4]; //All the rooms  
    public bool[] clicked = new bool[4]; //Array that checks if you're in e certain room
    new Animation animation;
    public float Timer = 0;//Timer for hiding the time machine after an inactive period of time.
    bool hidden = true; //bool that checks if it's hidden
    public int Choice = -1; //-1 - Start Room (You can't go back there) 0 - 1950, 1 - 1980, 2 - 2000, 3 - 2017
    public ParticleSystem parts;
    public int times_showed = 0;
    public GameObject script_ref;

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
        if(times_showed != 0) {parts.Play();}
        
        object_.SetActive(Toggle(hidden));
        hidden = Toggle(hidden);
        times_showed++;
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
            }
            else
            {
                SetTimer(10);
            }
            Choice++;
            
            if (Choice == 1) animation.CrossFade("choice1", 0.5f);
            if (Choice == 2) animation.CrossFade("choice2", 0.5f);
            if (Choice == 3) animation.CrossFade("choice3", 0.5f);
            if (Choice == 0) animation.CrossFade("choice4", 0.5f);
            if (Choice == Rooms.Length)
            {
                Choice = 0;
                animation.CrossFade("choice4", 0.5f);
            }
        }

    }

    void Teleportation(int _choice)
    {
        if (!clicked[_choice])
        {
            Player.GetComponent<player_lookat>().triggerdistance = 2;
            animation.CrossFade("teleportation", 1f);
            for (int i = 0; i < clicked.Length; i++)
            {
                clicked[i] = false;//Equilibrium!
            }
            SetTimer(10);           
            Player.transform.position = Rooms[_choice].transform.position;
            clicked[Choice] = true;
            script_ref.SendMessageUpwards("CameraTour", Choice, SendMessageOptions.DontRequireReceiver);
        }
    }

    void Awake()
    {
        animation = TimeMachine.GetComponent<Animation>();
        if (hidden)
        {
            Hide(TimeMachine);
        }
    }

    void Start()
    {
        Player.GetComponent<player_lookat>().triggerdistance = 20;
            
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
            try
            {
                Teleportation(Choice);
            }
            catch (Exception)
            {
                Debug.Log("Your choice is invalid.");
            }           
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

