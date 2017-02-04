using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crosshair : MonoBehaviour {

    public Texture2D crosshair_tex;
    public Rect position;
    public int size = 4; //the bigger, the smaller

    void Update()
    {
        position = new Rect((Screen.width - crosshair_tex.width/size) / 2, (Screen.height - crosshair_tex.height/size) / 2, crosshair_tex.width/ size, crosshair_tex.height/ size);
    }
    void OnGUI()
    {
        GUI.DrawTexture(position, crosshair_tex);
    }
}
