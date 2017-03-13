using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tv_interaction : MonoBehaviour {

    public MovieTexture movie_tex;
    public Material movie;
    public AudioSource movie_sound;
    public GameObject script_ref_audiomixer;
    public GameObject TV;
    public Material tvoff;
    public bool isTVon = false;

    private void Start()
    {
        TV.GetComponent<Renderer>().material = tvoff;
    }

    public void Interaction()
    {
        movie_tex.loop = true;
        movie_sound.loop = true;

        if (movie_tex.isPlaying)
        {
            movie_tex.Pause();
            movie_sound.Pause();
            script_ref_audiomixer.GetComponent<audiomixer>().songs[script_ref_audiomixer.GetComponent<audiomixer>().choice__].TransitionTo(1f);
            isTVon = false;
            TV.GetComponent<Renderer>().material = tvoff;

        }
        else
        {
            TV.GetComponent<Renderer>().material = movie;           
            script_ref_audiomixer.GetComponent<audiomixer>().songs[script_ref_audiomixer.GetComponent<audiomixer>().choice__ + 4].TransitionTo(1f);
            movie_sound.Play();
            movie_tex.Play();
            isTVon = true;
        }
    }
}
