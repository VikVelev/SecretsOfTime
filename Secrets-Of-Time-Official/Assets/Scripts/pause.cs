using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityStandardAssets.Characters.FirstPerson;


public class pause : MonoBehaviour
{
    public Camera MainCamera;
    public GameObject current_UI;
    public GameObject pause_UI;
    public GameObject player;
    public bool paused;
    public AudioMixerSnapshot mute;
    public MovieTexture[] movie_tex;
    public bool moviewasplaying = false;
    public GameObject[] interaction;
    public audiomixer audio_;
    public musicplayers[] musicplayer;

    int n;
    choices choice_re;

    private void Start()
    {
        choice_re = player.GetComponent<choices>();
    }

    public void pausetoggle()
    {
        if (!paused)
        {
            //disable stuff
            player.GetComponent<FirstPersonController>().enabled = false;
            player.GetComponent<pause>().enabled = false;
            choice_re.enabled = false;
            player.GetComponent<crosshair>().enabled = false;
            player.GetComponent<player_lookat>().enabled = false;
            player.GetComponent<crosshair>().enabled = false;
            current_UI.GetComponent<Canvas>().enabled = false;
            pause_UI.GetComponent<Canvas>().enabled = true;
            //actually pause         
            paused = true;
            Time.timeScale = 0;
            //stop sound
            mute.TransitionTo(0f);
            //Show cursor
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            //Check if there was tv on.
            if (choice_re.Choice >= 0 && movie_tex[choice_re.Choice].isPlaying)
            {
                movie_tex[choice_re.Choice].Pause();
                moviewasplaying = true;
            }
        }
        else
        {
            //unpause            
            Time.timeScale = 1;
            paused = false;

            //enable stuff
            choice_re.enabled = true;
            player.GetComponent<pause>().enabled = true;
            player.GetComponent<FirstPersonController>().enabled = true;
            player.GetComponent<crosshair>().enabled = true;
            player.GetComponent<player_lookat>().enabled = true;
            current_UI.GetComponent<Canvas>().enabled = true;
            pause_UI.GetComponent<Canvas>().enabled = false;
            player.GetComponent<crosshair>().enabled = true;

            //Sound

            if (choice_re.GetRoom() >= 0 && interaction[choice_re.GetRoom()].GetComponent<tv_interaction>().isTVon)
            {
                audio_.tv_sound[choice_re.Choice].TransitionTo(0f);
            } else if (choice_re.GetRoom() == 0 || choice_re.GetRoom() == 1)
            {
                audio_.other_sounds[choice_re.GetRoom()].TransitionTo(1f);
            } else
            {
                audio_.songs[choice_re.GetRoom()].TransitionTo(0f);
            }


            //Reenable TV if it was on
            if (moviewasplaying)
            {
                movie_tex[choice_re.Choice].Play();
                moviewasplaying = false;
            }

            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;

        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pausetoggle();
        }
    }
}