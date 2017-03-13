using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class pause : MonoBehaviour {
    public Camera MainCamera;
    public GameObject current_UI;
    public GameObject pause_UI;
    public GameObject player;
    public bool paused;
    public AudioMixerSnapshot[] snapshots;
    public MovieTexture[] movie_tex;
    public bool moviewasplaying = false;
    public GameObject[] interaction;

    public void pausetoggle()
    {
        if (!paused)
        {
            player.GetComponent<crosshair>().enabled = false;
            current_UI.GetComponent<Canvas>().enabled = false;            
            pause_UI.GetComponent<Canvas>().enabled = true;           
            paused = true;
            Time.timeScale = 0;
            snapshots[4].TransitionTo(0f);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            if (player.GetComponent<choices>().Choice >= 0)
            {
                if (movie_tex[player.GetComponent<choices>().Choice].isPlaying)
                {
                    movie_tex[player.GetComponent<choices>().Choice].Pause();
                    moviewasplaying = true;
                }
            }
        }
        else
        {            
            Time.timeScale = 1;
            current_UI.GetComponent<Canvas>().enabled = true;
            pause_UI.GetComponent<Canvas>().enabled = false;
            player.GetComponent<crosshair>().enabled = true;

            if (player.GetComponent<choices>().Choice >= 0)
            {
                if (interaction[player.GetComponent<choices>().Choice].GetComponent<tv_interaction>().isTVon)
                {
                    snapshots[player.GetComponent<choices>().Choice + 6].TransitionTo(1f);
                } else
                {
                    snapshots[player.GetComponent<choices>().Choice].TransitionTo(0f);
                }
            } else
            {
                snapshots[5].TransitionTo(0f);
            }
            if (moviewasplaying)
            {
                movie_tex[player.GetComponent<choices>().Choice].Play();
                moviewasplaying = false;
            }
            paused = false;
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

    void Awake()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}