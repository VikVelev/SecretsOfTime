using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class open_lookat : MonoBehaviour{

    public GameObject Canvas;
    public GameObject Interaction_Canvas = null;
    public bool IsInteractive = false;

    public void OnLookOn()
    {
        Canvas.GetComponent<Canvas>().enabled = true;       
        if (IsInteractive)
        {
            Interaction_Canvas.GetComponent<Canvas>().enabled = true;
        }
    }

    public void OnLookOff()
    {
        Canvas.GetComponent<Canvas>().enabled = false;
        if (IsInteractive)
        {
            Interaction_Canvas.GetComponent<Canvas>().enabled = false;
        }
    }
}
