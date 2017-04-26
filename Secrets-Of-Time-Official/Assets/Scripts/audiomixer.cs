using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class audiomixer : MonoBehaviour
{
    public AudioMixerSnapshot[] songs;
    public AudioMixerSnapshot[] tv_sound;
    public GameObject refs;
    public GameObject[] interaction;
    public int choice_;
    choices choices_r;
    
    private void Start()
    {
        choices_r = refs.GetComponent<choices>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (interaction[choice_].GetComponent<tv_interaction>().isTVon)
            {
                tv_sound[choice_].TransitionTo(1f);
            }
            else
            {
                songs[choice_].TransitionTo(1f);
            }            
          }      
    }

    void OnTriggerExit(Collider other)
    {    
        if (other.tag == "Player")
        {
            songs[choices_r.GetRoom()].TransitionTo(1f);
        }        
    }

    void Update()
    {
        choice_ = choices_r.Choice;
    }
}