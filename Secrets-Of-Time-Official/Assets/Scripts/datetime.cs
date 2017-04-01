using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class datetime : MonoBehaviour
{
    public Text _time;
    private void Update()
    {
        _time.text = DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute;
   }

}
