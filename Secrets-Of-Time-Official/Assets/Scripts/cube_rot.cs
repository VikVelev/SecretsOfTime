using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cube_rot : MonoBehaviour {

    void OnMouseDown()
    {
        GetComponent<Animation>().Play();
    }

}
