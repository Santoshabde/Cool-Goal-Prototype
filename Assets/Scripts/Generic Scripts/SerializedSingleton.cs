using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SerializedSingleton<T> : MonoBehaviour where T: MonoBehaviour
{
    private static T instance;

    public static T Instance
    {
        get
        {
            if (instance == null)
                instance = FindObjectOfType<T>();

            return instance;
        }
    }
}
