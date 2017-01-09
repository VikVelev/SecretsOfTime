using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour {

    public GameObject Camera;
    GameObject rayhit_obj_old;
    GameObject rayhit_obj;
    RaycastHit rayhit;
    Vector3 Raycast_pos;

    void Update() {

        Raycast_pos = Camera.transform.position;
        if(Physics.Raycast(Raycast_pos, Camera.transform.forward, out rayhit, 10))
        {
            Debug.DrawRay(Camera.transform.position, Camera.transform.forward * 10, Color.red, float.PositiveInfinity);
            
            rayhit_obj = rayhit.collider.gameObject;
            Debug.Log(rayhit_obj.name);
            if (rayhit_obj != rayhit_obj_old)
            {
                rayhit_obj.SendMessageUpwards("OnTriggerEnter", null, SendMessageOptions.DontRequireReceiver);
                if (rayhit_obj_old != null)
                {
                    rayhit_obj_old.SendMessageUpwards("OnTriggerExit", null, SendMessageOptions.DontRequireReceiver);
                }
            } 
            rayhit_obj_old = rayhit_obj;
        }
        else if(rayhit_obj_old != null)
        {
            rayhit_obj_old.SendMessageUpwards("OnTriggerExit", null, SendMessageOptions.DontRequireReceiver);
        }        

    }
}
