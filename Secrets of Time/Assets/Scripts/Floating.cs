using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floating : MonoBehaviour, IRaycast23 {

    public GameObject Canvas;

    public void OnTriggerEnter()
    {
        Canvas.GetComponent<Canvas>().enabled = true;
    }

    public void OnTriggerExit()
    {
        Canvas.GetComponent<Canvas>().enabled = false;
    }
}
