using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pause : MonoBehaviour {
    public Camera MainCamera;
    public GameObject current_UI;
    public GameObject pause_UI;
    public GameObject player;
    bool paused;

    public void pausetoggle()
    {
        if (!paused)
        {
            player.GetComponent<crosshair>().enabled = false;
            current_UI.GetComponent<Canvas>().enabled = false;            
            pause_UI.GetComponent<Canvas>().enabled = true;           
            paused = true;
            Time.timeScale = 0;
            
        }
        else
        {            
            Time.timeScale = 1;
            current_UI.GetComponent<Canvas>().enabled = true;
            pause_UI.GetComponent<Canvas>().enabled = false;
            player.GetComponent<crosshair>().enabled = true;

            paused = false;

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