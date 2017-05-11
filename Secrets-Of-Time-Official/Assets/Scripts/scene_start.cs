using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scene_start : MonoBehaviour {
    public GameObject[] todisable;
    void Start(){
        Time.timeScale = 1;
    }
    void ChangeScene()
    {
        SceneManager.LoadScene(1);
        for (int i = 0; i < todisable.Length; i++)
        {
            todisable[i].gameObject.SetActive(false);
        }
        //DontDestroyOnLoad(todisable[todisable.Length - 1]);

    }

    void QuitGame()
    {
        Application.Quit();
        
    }
}
