using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseConfig<T> : ScriptableObject, IConfig where T: IValueKeyConfig
{
    [SerializeField] private List<T> listData;

    public static Dictionary<string, T> data;

    private void OnValidate()
    {
        Refresh();
    }

    [ContextMenu("Refresh Config")]
    public void Refresh()
    {
        data = new Dictionary<string, T>();

        foreach (var item in listData)
        {
            data.Add(item.key, item);
        }
    }
}

public interface IValueKeyConfig
{
    string key { get; }
}

public interface IConfig
{
    void Refresh();
}