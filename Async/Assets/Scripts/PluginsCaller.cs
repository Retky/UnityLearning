using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Using to call the plugins
using System.Runtime.InteropServices;
using TMPro;

public class PluginsCaller : MonoBehaviour
{
    [SerializeField] private GameObject userInput;

    [DllImport("__Internal")]
    private static extern void Base();

    [DllImport("__Internal")]
    private static extern void NewNum();

    [DllImport("__Internal")]
    private static extern void DelayNum();

    [DllImport("__Internal")]
    private static extern void SaveToLocal(string str);

    [DllImport("__Internal")]
    private static extern void LoadFromLocal();

    [DllImport("__Internal")]
    private static extern void TextFromPlugin();

    public void CheckPlugin()
    {
        Base();
    }

    public void ChangeNumber()
    {
        NewNum();
    }

    public void DelayNumber()
    {
        DelayNum();
    }

    public void SaveString()
    {
        string savingText = userInput.GetComponent<TMP_InputField>().text;
        Debug.Log(savingText);
        SaveToLocal(savingText);
    }

    public void LoadNumber()
    {
        LoadFromLocal();
    }

    public void TextFromPluginMethod()
    {
        TextFromPlugin();
    }
}
