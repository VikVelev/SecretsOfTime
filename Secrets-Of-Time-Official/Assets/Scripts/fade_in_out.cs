using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class fade_in_out : MonoBehaviour {

    public Text[] txt = new Text[1];
    public Image[] img = new Image[1];
    public Canvas root;
    public float fade_time = 0.1f;

    void Start () {
 
    }

    void Update()
    {
            if (!root.GetComponent<Canvas>().enabled)
            {
                if (txt == null)
                {
                    for (int i = 0; i < img.Length; i++)
                    {
                        img[i].CrossFadeAlpha(0, fade_time, false);
                    }
                }
                else
                {
                    for (int i = 0; i < txt.Length; i++)
                    {
                        try
                        {
                            txt[i].CrossFadeAlpha(0, fade_time, false);
                        }
                        catch (Exception)
                        {

                        }
                    }
                }
            if (txt != null && img != null)
            {
                for (int i = 0; i < txt.Length; i++)
                {
                    try
                    {
                        txt[i].CrossFadeAlpha(0, fade_time, false);
                    }
                    catch (Exception)
                    {

                    }
                }
                for (int i = 0; i < img.Length; i++)
                {
                    img[i].CrossFadeAlpha(0, fade_time, false);
                }
            }
        }
            else
            {
                if (txt == null && img != null)
                {
                    for (int i = 0; i < img.Length; i++)
                    {
                        img[i].CrossFadeAlpha(1f, fade_time, false);
                    }
                }
                else
                {
                }

                if (txt != null && img != null)
                {
                for (int i = 0; i < txt.Length; i++)
                {
                    try
                    {
                        txt[i].CrossFadeAlpha(1, fade_time, false);
                    }
                    catch (Exception)
                    {

                    }
                }
                for (int i = 0; i < img.Length; i++)
                {
                    img[i].CrossFadeAlpha(1f, fade_time, false);
                }
            }
        }

        
    }
}
