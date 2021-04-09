using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Dbg
{

#if UNITY_EDITOR
    public static void Log(string message)
    {
        Debug.Log(message);
    }
    public static void Log(string message, Color col)
    {
        Debug.Log($"<color=#{ColorUtility.ToHtmlStringRGB(col)}>{message}</color>");
    }
    public static void Log<T>(T message)
    {
        Dbg.Log(message.ToString());
    }
    public static void Log<T>(T message, Color col)
    {
        Dbg.Log(message.ToString(), col);
    }
#else
    [System.Diagnostics.Conditional("DEVELOPMENT_BUILD")]
    public static void      Log     (string message) {
        Debug.Log(message);
    }

    [System.Diagnostics.Conditional("DEVELOPMENT_BUILD")]
    public static void      Log     (string message, Color col) {
        Debug.Log($"<color=#{ColorUtility.ToHtmlStringRGB(col)}>{message}</color>");
    }

    [System.Diagnostics.Conditional("DEVELOPMENT_BUILD")]
    public static void      Log<T>  (T message) {
        Dbg.Log(message.ToString());
    }

    [System.Diagnostics.Conditional("DEVELOPMENT_BUILD")]
    public static void      Log<T>  (T message, Color col) {
        Dbg.Log(message.ToString(), col);
    }
#endif

}
