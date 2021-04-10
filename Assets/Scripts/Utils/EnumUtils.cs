using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnumUtils : ASingleton<EnumUtils>
{
    [RuntimeInitializeOnLoadMethod] public static void SelfAwake() { Get(); }

    public List<T> GetValues<T>()
    {
        var vals = Enum.GetValues(typeof(T));
        List<T> returnVals = new List<T>();

        foreach (T val in vals)
        {
            returnVals.Add(val);
        }

        return returnVals;
    }

}
