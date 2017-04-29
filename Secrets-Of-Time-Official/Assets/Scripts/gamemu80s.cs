using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityGB;
using System;
using System.IO;


public class gamemu80s : MonoBehaviour {

    public string Filename;
    public Renderer ScreenRenderer;
    private Dictionary<KeyCode, EmulatorBase.Button> keyMapping;
    public atari_interaction reff;

    public EmulatorBase Emulator
    {
        get;
        private set;
    }

    void Start()
    {
        keyMapping = new Dictionary<KeyCode, EmulatorBase.Button>();

        keyMapping.Add(KeyCode.UpArrow, EmulatorBase.Button.A);
        keyMapping.Add(KeyCode.DownArrow, EmulatorBase.Button.Down);
        keyMapping.Add(KeyCode.LeftArrow, EmulatorBase.Button.Left);
        keyMapping.Add(KeyCode.RightArrow, EmulatorBase.Button.Right);
        keyMapping.Add(KeyCode.X, EmulatorBase.Button.B);
        keyMapping.Add(KeyCode.Return, EmulatorBase.Button.Start);
        keyMapping.Add(KeyCode.LeftShift, EmulatorBase.Button.Select);

        IVideoOutput drawable = new DefaultVideoOutput();
        IAudioOutput audio = GetComponent<DefaultAudioOutput>();
        ISaveMemory saveMemory = new DefaultSaveMemory();
        Emulator = new Emulator(drawable, audio, saveMemory);
        ScreenRenderer.material.mainTexture = ((DefaultVideoOutput)Emulator.Video).Texture;

        GetComponent<AudioSource>().enabled = true;

        StartCoroutine(LoadRom(Filename));
    }

    void Update()
    {
        if (reff.isAtariOn)
        {
            foreach (KeyValuePair<KeyCode, EmulatorBase.Button> entry in keyMapping)
            {
                if (Input.GetKeyDown(entry.Key))
                    Emulator.SetInput(entry.Value, true);
                else if (Input.GetKeyUp(entry.Key))
                    Emulator.SetInput(entry.Value, false);
            }
        }
    }

    public IEnumerator LoadRom(string filename)
    {
        string path;
        #if UNITY_EDITOR
        path = "file://" + Environment.CurrentDirectory + "\\Assets\\StreamingAssets\\" + filename;
        #elif UNITY_STANDALONE_WIN
        path = "file://" + Environment.CurrentDirectory + "\\Secrets of Time_Data\\StreamingAssets\\" + filename;
        #endif
        WWW www = new WWW(path);
        yield return www;

        if (www.error == null)
        {
            Emulator.LoadRom(www.bytes);
            //StartCoroutine(Run());
        }
        else
            Debug.Log("Error during loading the rom.\n" + www.error);
    }

    public IEnumerator Run()
    {
        gameObject.GetComponent<AudioSource>().enabled = true;
        while (true)
        {
            Emulator.RunNextStep();
            yield return null;
        }
    }

    public void Save(string name, byte[] data)
    {
        if (data == null)
            return;

        string path = null;
#if UNITY_STANDALONE_WIN || UNITY_STANDALONE_WIN
        path = Environment.CurrentDirectory + "\\Assets\\StreamingAssets\\";
#else
		Debug.Log("I don't know where to save data on this platform.");
#endif

        if (path != null)
        {
            try
            {
                File.WriteAllBytes(path + name + ".sav", data);
            }
            catch (Exception e)
            {
                Debug.Log("Couldn't save data file.");
                Debug.Log(e.Message);
            }
        }
    }

    public byte[] Load(string name)
    {
        string path = null;
#if UNITY_STANDALONE_WIN || UNITY_STANDALONE_WIN
        path = Environment.CurrentDirectory + "\\Assets\\StreamingAssets\\";
#else
		Debug.Log("I don't know where to load data on this platform.");
#endif

        byte[] loadedData = null;

        if (path != null)
        {
            try
            {
                loadedData = File.ReadAllBytes(path + name + ".sav");
            }
            catch (System.Exception e)
            {
                Debug.Log("Shit");
                Debug.Log(e.Message);
            }
        }
        return loadedData;
    }
}
