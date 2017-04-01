using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class soundvalue_gui : MonoBehaviour {

    public Slider slider;
    public GameObject slider_;
    public soundcontrol soundcontrol_;
    public float timer;

    private void Start()
    {
        slider_.SetActive(false);
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        
        if (slider.value != soundcontrol_.volume)
        {
            slider_.SetActive(true);
            timer = 3;     
        }

        if(timer < 0)
        {
            slider_.SetActive(false);
        }

        Mathf.Clamp(timer, 0, 3);
        slider.value = soundcontrol_.volume;
    }
}
