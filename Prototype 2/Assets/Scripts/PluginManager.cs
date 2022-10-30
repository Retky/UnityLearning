using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

public class PluginManager : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void LoadLocalStore();

    [DllImport("__Internal")]
    private static extern void SaveLocalStore(string jsonString);

    

    public void loadScore()
    {
        LoadLocalStore();
    }

    public void SaveScore(string jsonString)
    {
        SaveLocalStore(jsonString);
    }
}
