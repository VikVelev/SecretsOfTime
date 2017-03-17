using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class terminal : MonoBehaviour {

    public Canvas terminal_start;
    public Text output;
    public GameObject player;
    public Text input;
    public InputField input_field;
    bool terminal_on = false;
    string currentText;
    string command;
    int lines = 0;
    public GameObject[] disable;
    

    public void Interaction()
    {
        if (!terminal_on)
        {
            for (int i = 0; i < disable.Length; i++)
            {
                disable[i].SetActive(false);
            }
            terminal_start.GetComponent<Canvas>().enabled = true;
            player.GetComponent<FirstPersonController>().enabled = false;
            player.GetComponent<pause>().enabled = false;
            player.GetComponent<crosshair>().enabled = false;
            player.GetComponent<player_lookat>().enabled = false;
            Cursor.lockState = CursorLockMode.Locked;
            //Cursor.visible = true;
            //Cursor.lockState = CursorLockMode.None;
            input_field.ActivateInputField();
            terminal_on = true;

        } else
        {
            //Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            terminal_start.GetComponent<Canvas>().enabled = false;
            player.GetComponent<pause>().enabled = true;
            player.GetComponent<FirstPersonController>().enabled = true;
            player.GetComponent<crosshair>().enabled = true;
            player.GetComponent<player_lookat>().enabled = true;
            for (int i = 0; i < disable.Length; i++)
            {
                disable[i].SetActive(true);
            }
            terminal_on = false;
        }
    }

    public void AddText(string text)
    {
        output.text += "\n" + text;
        input_field.text = "";
        lines++;
        if (lines > 21)
        {
            output.text = "";
            lines = 0;
        }
    }

    private void Update()
    {
        if (terminal_on && Input.GetButtonDown("Submit"))
        {
            if (input.text.Trim() != "" && input.text.Length < 40)
            {
                command = input.text;
                AddText(input.text);
                input_field.ActivateInputField();

                if (command == "dir")
                {
                    if(lines + 12 > 22)
                    {
                        output.text = "";
                        lines = 0;
                    }
                    AddText("Directory of C:/Secrets of Time");
                    AddText("1981-08-18    <DIR>   TAR");
                    AddText("1981-08-19    <DIR>   HUM");
                    AddText("1981-08-18    <DIR>   IPC");
                    AddText("1981-08-18    <DIR>   SOS");
                    AddText("1981-08-18    <DIR>   ");
                    AddText("1981-08-18    <DIR>   I@A");
                    AddText("1981-08-18    <DIR>   SO3");
                    AddText("1981-08-18    <DIR>   ");
                    AddText("1981-08-18    <DIR>   F02");
                    AddText("1981-08-18    <DIR>   AOS");
                    AddText("1981-08-18    <DIR>   KOH");
                    AddText("1981-08-18    <DIR>   EPS");
                }
                else if( command == "clear")
                {
                    output.text = "";
                    lines = 0;
                }
                else if (command == "help")
                {
                    AddText("Available Commands: dir, clear, help, shutdown, uptime");
                }
                else if(command == "shutdown")
                {
                    output.text = "";
                    Interaction();
                }
                else if(command == "uptime")
                {
                    AddText("Since the begining");
                }
                else
                {
                    AddText("There is no such command. Type 'help' for help.");
                }
            } else if(input.text.Length > 39)
            {
                AddText("Your command is too long.");
            }
        }
        if(terminal_on && Input.GetButton("Cancel"))
        {
            Interaction();
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

}
