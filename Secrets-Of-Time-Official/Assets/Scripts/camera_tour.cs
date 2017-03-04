using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_tour : MonoBehaviour {

    public Camera[] cameras = new Camera[5];
    public GameObject scriptref;
	
    public void CameraTour(int choice)
    {
        Debug.Log(cameras[choice].name);
        cameras[4].GetComponent<Camera>().enabled = false;
        cameras[choice].GetComponent<Camera>().enabled = true;
        cameras[choice].GetComponent<Animator>().Play("enter_room", 0, float.NegativeInfinity);
          
    }

	void Update () {

        if (scriptref.GetComponent<choices>().Choice > -1)
        {
            if (!cameras[scriptref.GetComponent<choices>().Choice].GetComponent<Animation>().isPlaying)
            {
                Debug.Log(cameras[scriptref.GetComponent<choices>().Choice].name);
                cameras[scriptref.GetComponent<choices>().Choice].GetComponent<Camera>().enabled = false;
                cameras[4].GetComponent<Camera>().enabled = true;
            }
        }		
	}
}
