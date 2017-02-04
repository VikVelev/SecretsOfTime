using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class open_lookat : MonoBehaviour{
    public GameObject Canvas;

    public void OnLookOn()
    {
        Canvas.GetComponent<Canvas>().enabled = true;
    }
    public void OnLookOff()
    {
        Canvas.GetComponent<Canvas>().enabled = false;
    }

}
