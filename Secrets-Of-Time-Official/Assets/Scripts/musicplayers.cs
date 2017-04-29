using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicplayers : MonoBehaviour {

    public bool isMusicOn;
    public AudioSource sound;
    public audiomixer audiomixer;
    public choices ref_player;
    public tv_interaction tv;

    void Interaction()
    {
        if (isMusicOn)
        {
            //TODO
            sound.Pause();

            if (!tv.isTVon)
            {
                audiomixer.songs[ref_player.GetRoom()].TransitionTo(1f);
            } else
            {
                audiomixer.tv_sound[ref_player.GetRoom()].TransitionTo(1f);
            }

            GetComponent<Animation>().Stop();
            isMusicOn = false;
        }
        else
        {

            //!TODO
            sound.Play();

            GetComponent<Animation>().Play();
                     
            audiomixer.other_sounds[ref_player.GetRoom()].TransitionTo(1f);

            isMusicOn = true;
        }
    }
}
