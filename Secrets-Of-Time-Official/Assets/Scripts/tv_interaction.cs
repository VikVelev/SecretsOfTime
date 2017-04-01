using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tv_interaction : MonoBehaviour {

    public MovieTexture movie_tex;
    public Material movie;
    public AudioSource movie_sound;
    public audiomixer script_ref_audiomixer;
    public choices script_ref_player;
    public GameObject TV;
    public Material tvoff;
    public bool isTVon = false;

     int n;

    void Start()
    {
        TV.GetComponent<Renderer>().material = tvoff;
    }

    public void Interaction()
    {
        movie_tex.loop = true;
        movie_sound.loop = true;

        if (isTVon)
        {
            movie_tex.Pause();
            movie_sound.Pause();
                      
            script_ref_audiomixer.songs[script_ref_player.GetRoom()].TransitionTo(1f);

            isTVon = false;
            TV.GetComponent<Renderer>().material = tvoff;

        }
        else
        {
            TV.GetComponent<Renderer>().material = movie;
            script_ref_audiomixer.tv_sound[script_ref_player.GetRoom()].TransitionTo(1f);
            movie_sound.Play();
            movie_tex.Play();
            isTVon = true;
        }
    }
}
