using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class choices : MonoBehaviour {

    public GameObject Player;
    public GameObject TimeMachine;
    public GameObject[] Rooms = new GameObject[4]; //All the rooms  
    public bool[] clicked = new bool[4]; //Array that checks if you're in e certain room
    Animation animation_;
    public float Timer = 0;//Timer for hiding the time machine after an inactive period of time.
    public bool hidden = true; //bool that checks if it's hidden
    public int Choice = -1; //-1 - Start Room (You can't go back there) 0 - 1950, 1 - 1980, 2 - 2000, 3 - 2017
    public ParticleSystem parts;
    public int times_showed = 0;
    public ParticleSystem particles;
    public AudioSource tel_effect;
    public GameObject Pause_ref;

    public Vector3 GetPosition(GameObject _Object)
    {
        return _Object.transform.position;
    }

    public Quaternion GetRotation(GameObject _Object)
    {
        return _Object.transform.rotation;
    }
    
    void SetTimer(float _num)
    {
        Timer = _num;
    }

    public void Hide(GameObject object_)
    {
        if(times_showed != 0) {parts.Play();}
        object_.SetActive(Toggle(hidden));
        hidden = Toggle(hidden);
        times_showed++;
    }

    public bool Toggle(bool _toggle)
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

    public int GetRoom() //Gets the room you are currently in.
    {
        int n = 0;
        try
        {
            if (clicked[Choice]) return Choice;
            else 
               n = 0;                           
               while (!clicked[n]) n++;
            return n;
        }
        catch (Exception)
        {
            return -1;
        }
    }

    void Choose()
    {       
        if (!animation_.isPlaying || animation_.IsPlaying("time_machine_idle"))
        {
            if (!hidden) Hide(TimeMachine);
            else SetTimer(10);

            Choice++;
            
            if (Choice == 1) animation_.CrossFade("choice1", 0.5f);
            if (Choice == 2) animation_.CrossFade("choice2", 0.5f);
            if (Choice == 3) animation_.CrossFade("choice3", 0.5f);
            if (Choice == 0) animation_.CrossFade("choice4", 0.5f);
            if (Choice == Rooms.Length)
            {
                Choice = 0;
                animation_.CrossFade("choice4", 0.5f);
            }
        }
    }

    void Teleportation(int _choice)
    {
        if (!clicked[_choice])
        {
            tel_effect.Play();   
            if (!particles.isPlaying)
            {
                particles.Play();
            }
            else
            {
                particles.Stop();
                particles.Play();
            }
            Player.GetComponent<player_lookat>().triggerdistance = 3;
                animation_.CrossFade("teleportation", 1f);
                for (int i = 0; i < clicked.Length; i++)
                {
                    clicked[i] = false;//Equilibrium!
                }
                SetTimer(10);
                Player.transform.position = Rooms[_choice].transform.position;
                clicked[Choice] = true;
        }
    }

    void Awake()
    {
        animation_ = TimeMachine.GetComponent<Animation>();
        if (hidden)
        {
            Hide(TimeMachine);
        }
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Start()
    {
        Player.GetComponent<player_lookat>().triggerdistance = 20;      
    }

    void Update()
    {
        Debug.Log(GetRoom());

        if (!Pause_ref.GetComponent<pause>().paused)
        {
            Timer -= Time.deltaTime; // Timer

            if (!hidden) SetTimer(10);
            if (Timer <= 0) Hide(TimeMachine);

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                try
                {
                    Teleportation(Choice);
                }
                catch (Exception)
                {
                   
                }
            }
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                Choose();
            }
            if (!animation_.isPlaying)
            {
                animation_.CrossFade("time_machine_idle", 0.5f);
            }
        }
    }
}

