using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ASingleton<T> where T : new()
{
    private static T _instance;
    public static T Get()
    {
        if (_instance == null)
        {
            _instance = new T();
        }
        return _instance;
    }

    protected ASingleton() { Reset(); }

    public virtual void Reset() { }
    public virtual void Clear() { }

}

