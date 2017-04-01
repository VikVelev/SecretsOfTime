using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loookat : MonoBehaviour {

    public Transform target;
	
	// Update is called once per frame
	void Update () {
        this.transform.LookAt(target);
	}
}
