using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

public class PluginManager : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void TestPlugin();

    public void Test()
    {
        TestPlugin();
    }
}
