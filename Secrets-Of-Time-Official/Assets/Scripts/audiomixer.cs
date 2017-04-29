using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class audiomixer : MonoBehaviour
{
    public AudioMixerSnapshot[] songs;
    public AudioMixerSnapshot[] tv_sound;
    public AudioMixerSnapshot[] other_sounds;
    public GameObject refs;
    public musicplayers music;
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
            songs[choice_].TransitionTo(1f); //Trust me, it makes sense. Idk why but it does.

            if (interaction[choice_].GetComponent<tv_interaction>().isTVon)
            {
                tv_sound[choice_].TransitionTo(1f);
            } else if (choices_r.GetRoom() == 1 || choices_r.GetRoom() == 0)
            {
                if (music.isMusicOn)
                {
                    other_sounds[choice_].TransitionTo(1f);
                }
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