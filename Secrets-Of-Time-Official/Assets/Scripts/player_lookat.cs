using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_lookat : MonoBehaviour
{

    public GameObject Camera;
    GameObject rayhit_obj_old;
    GameObject rayhit_obj;
    RaycastHit rayhit;
    Vector3 Raycast_pos;
    public int triggerdistance;

    void Update()
    {
        Raycast_pos = Camera.transform.position;

        if (Physics.Raycast(Raycast_pos, Camera.transform.forward, out rayhit, 1000))
        {
            Debug.DrawRay(Camera.transform.position, Camera.transform.forward * 10, Color.red, float.PositiveInfinity);
            rayhit_obj = rayhit.collider.gameObject;

            Debug.Log(rayhit_obj.name);
            if (rayhit_obj != rayhit_obj_old && rayhit_obj_old != null)
            {
                rayhit_obj_old.SendMessageUpwards("OnLookOff", null, SendMessageOptions.DontRequireReceiver);
                Debug.Log("Exiting...");
            }
            if (rayhit_obj != rayhit_obj_old && rayhit.distance < triggerdistance)
            {
                rayhit_obj.SendMessageUpwards("OnLookOn", null, SendMessageOptions.DontRequireReceiver);
                Debug.Log("Opening Canvas...");
            }

            rayhit_obj_old = rayhit_obj;
        }

    }
}
