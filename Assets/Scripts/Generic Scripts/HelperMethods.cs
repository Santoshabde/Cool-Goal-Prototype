using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class HelperMethods
{
    public static float Clamp01Range(this float value, float min, float max)
    {
        if(Mathf.Abs(value) >= max)
        {
            if (value > 0)
                return 1;
            else
                return -1;
        }

        return (value - min) / max;
    }
}
