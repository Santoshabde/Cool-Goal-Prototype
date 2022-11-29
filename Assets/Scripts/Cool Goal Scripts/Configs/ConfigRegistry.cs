using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfigRegistry : MonoBehaviour
{
    [SerializeField] private List<ScriptableObject> baseConfigs;

    private void Awake()
    {
        foreach (IConfig item in baseConfigs)
        {
            item.Refresh();
        }
    }
}
