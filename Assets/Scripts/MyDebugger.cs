using System;
using UnityEngine;

public class MyDebugger
{
    public static void FormatDebug(string stringToPrint, params System.Object[] args) {
        Debug.Log(String.Format(stringToPrint, args));
    }
}
