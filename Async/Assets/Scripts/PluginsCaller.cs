using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Using to call the plugins
using System.Runtime.InteropServices;

public class PluginsCaller : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void Base();

    [DllImport("__Internal")]
    private static extern void NewNum();

    [DllImport("__Internal")]
    private static extern void DelayNum();

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
}
