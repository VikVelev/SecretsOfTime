using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class soundcontrol : MonoBehaviour {
    public float volume;
    public float sensitivity = 3;

	void Update () {

        volume = AudioListener.volume;

        if (Input.GetAxis("Mouse ScrollWheel") != 0f)
        {
            volume += Input.GetAxis("Mouse ScrollWheel")/sensitivity;

            if(volume > 1f)
            {
                volume = 1f;
            }
            else if(volume < 0f)
            {
                volume = 0f;
            }
            AudioListener.volume = volume;
        }
    }
}
