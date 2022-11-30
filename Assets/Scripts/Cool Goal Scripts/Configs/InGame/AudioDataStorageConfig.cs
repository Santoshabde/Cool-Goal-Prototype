using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AudioData", menuName = "InGameConfigs/AudioDataConfig", order = 1)]
public class AudioDataStorageConfig : BaseConfig<AudioData>
{
    
}

[System.Serializable]
public class AudioData : IValueKeyConfig
{
    public string key => audioName;

    public string audioName;
    public AudioClip audioClip;
    [Range(0, 1)]
    public float volume = 1;
    [Range(0.1f, 3f)]
    public float pitch = 1;
    [HideInInspector]
    public AudioSource source;
    public bool loop = false;
}

