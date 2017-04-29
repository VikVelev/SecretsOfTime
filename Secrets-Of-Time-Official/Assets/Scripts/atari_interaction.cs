using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;


public class atari_interaction : MonoBehaviour {

    public Canvas canvas_tut;
    public Camera character_camera;
    public GameObject Display;
    public CharacterController character;
    public GameObject player;
    public GameObject[] disable;
    public bool isAtariOn;
    public GameObject emu_renderer;
    public audiomixer adm;
    public tv_interaction tv;
    public musicplayers music;
    

    //used for storing positions and rotations
    Vector3 cam_pos;
    Quaternion cam_rot;
    bool firsttime_on = false;
    choices char_choice;

    void Start()
    {
        emu_renderer.GetComponent<MeshRenderer>().enabled = false;
        char_choice = player.GetComponent<choices>();
    }

    void Interaction() {

        if (!isAtariOn)
        {
            if (!firsttime_on)
            {
                //Start if it's not started
                StartCoroutine(gameObject.GetComponent<gamemu80s>().Run());
                firsttime_on = true;
            }

            //Switches to atari audio
            adm.songs[4].TransitionTo(1f);

            //Disabling stuff
            for (int i = 0; i < disable.Length - 1; i++)
            {
                disable[i].SetActive(false);
            }

            if (char_choice.hidden)
            {
                char_choice.Hide(disable[3]);
            }

            character.enabled = false;
            char_choice.enabled = false;
            player.GetComponent<FirstPersonController>().enabled = false;
            player.GetComponent<pause>().enabled = false;
            player.GetComponent<crosshair>().enabled = false;
            player.GetComponent<player_lookat>().enabled = false;

            canvas_tut.GetComponent<Canvas>().enabled = true;
            //Storing current rotation and position
            cam_pos = character_camera.transform.position;
            cam_rot = character_camera.transform.rotation;
            character_camera.transform.position = Display.transform.position;
            character_camera.transform.rotation = Display.transform.rotation;
            //Turns the atari screen on
            emu_renderer.GetComponent<MeshRenderer>().enabled = true;

            isAtariOn = true;
        }
        else
        {
            //Enabling stuff

            for (int i = 0; i < disable.Length - 1; i++)
            {
                disable[i].SetActive(true);
            }

            character.enabled = true;
            char_choice.enabled = true;
            player.GetComponent<FirstPersonController>().enabled = true;
            player.GetComponent<pause>().enabled = true;
            player.GetComponent<crosshair>().enabled = true;
            player.GetComponent<player_lookat>().enabled = true;

            char_choice.Hide(disable[3]);

            canvas_tut.GetComponent<Canvas>().enabled = false;
            //Setting back the position and rotation to it's original ones.
            character_camera.transform.position = cam_pos;
            character_camera.transform.rotation = cam_rot;
            //Turns off
            emu_renderer.GetComponent<MeshRenderer>().enabled = false;

            if (music.isMusicOn)
            {
                adm.other_sounds[1].TransitionTo(1f);
            } else if (tv.isTVon)
            {
                adm.tv_sound[char_choice.GetRoom()].TransitionTo(1f);
            } else
            {
                adm.songs[char_choice.GetRoom()].TransitionTo(1f);
            }

            Cursor.lockState = CursorLockMode.Locked;

            isAtariOn = false;          
        }
    }

    void Update() {

        if (!isAtariOn && !tv.isTVon && char_choice.GetRoom() == 1)
        {
            //adm.songs[char_choice.GetRoom()].TransitionTo(1f);
        }

        if (isAtariOn && Input.GetButton("Cancel"))
        {
            Interaction();
        }
    }
}
