using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ui_curro_sprch : MonoBehaviour {

    public Sprite[] room_sprites = new Sprite[5];
    public GameObject image_can;
    public GameObject player;
    choices what;

    void Start()
    {
        player = GameObject.Find("FPSController");
        what = player.GetComponent<choices>();               
    }

    void Update()
    {
        if (what.clicked[what.Choice])
        {
            image_can.GetComponent<Image>().sprite = room_sprites[what.Choice + 1];
        }
    }


}
