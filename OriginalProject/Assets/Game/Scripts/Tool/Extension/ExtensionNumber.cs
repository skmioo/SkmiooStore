using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ExtensionNumber
{
    public static int Clamp(this int value, int a, int b)
    {
        return Mathf.Clamp(value, a, b);
    }
}
