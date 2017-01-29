using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInfo : MonoBehaviour {

    public GameObject Canvas;

    void OnTriggerEnter()
    {
        Canvas.GetComponent<Canvas>().enabled = true;
    }

    void OnTriggerStay()
    {
        Canvas.GetComponent<Canvas>().enabled = true;
    }
    void OnTriggerExit()
    {
        Canvas.GetComponent<Canvas>().enabled = false;
    }

}
