﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class audiomixer : MonoBehaviour
{
    public AudioMixerSnapshot[] songs;
    public GameObject refs;
    public float bpm = 128;
    int choice__;


    private float m_TransitionIn;
    private float m_TransitionOut;
    private float m_QuarterNote;

    // Use this for initialization
    void Start()
    {
        m_QuarterNote = 60 / bpm;
        m_TransitionIn = m_QuarterNote;
        m_TransitionOut = m_QuarterNote * 32;

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.name == "FPSController")
        {
            songs[choice__].TransitionTo(m_TransitionIn);
        }
       
    }

    void OnTriggerExit(Collider other)
    {
        if (other.name == "FPSController")
        {
            songs[choice__].TransitionTo(m_TransitionOut);
        }
        
    }

    void Update()
    {

        choice__ = refs.GetComponent<choices>().Choice;
    }


}