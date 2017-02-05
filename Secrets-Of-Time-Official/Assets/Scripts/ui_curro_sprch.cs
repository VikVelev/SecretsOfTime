using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ui_curro_sprch : MonoBehaviour {

    public Sprite[] room_sprites = new Sprite[5];
    public GameObject image_can;
    public GameObject player;
    choices player_script;

    void Start()
    {
        player = GameObject.Find("FPSController");
        player_script = player.GetComponent<choices>();               
    }

    void Update()
    {
        try
        {
            if (player_script.clicked[player_script.Choice])
            {
                image_can.GetComponent<Image>().sprite = room_sprites[player_script.Choice + 1];
            }
        }
        catch (System.Exception)
        {
            Debug.Log("Index is -1. Don't mind me");
        }
        
    }


}
