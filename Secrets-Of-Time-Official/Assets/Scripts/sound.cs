﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sound : MonoBehaviour {

    public Toggle Sound;
    public GameObject Checkmark;
    public Sprite[] On_Off = new Sprite[2];
    public AudioSource Audio;

	void Update () {
        if (Sound.isOn)
        {
            Checkmark.GetComponent<Image>().sprite = On_Off[0];
            Audio.mute = false;
        }
        else
        {Checkmark.GetComponent<Image>().sprite = On_Off[1];
            Audio.mute = true;
        }
    }
}