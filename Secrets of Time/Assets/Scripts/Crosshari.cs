using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshari : MonoBehaviour
{
    public Texture2D crosshair;
    public Rect position;
    // Use this for initialization
    void Start()
    {

    }
    void Update()
    {
        position = new Rect((Screen.width - crosshair.width) / 2, (Screen.height - crosshair.height) / 2, crosshair.width, crosshair.height);
    }
    void OnGUI()
    {
        GUI.DrawTexture(position, crosshair);
    }
}
