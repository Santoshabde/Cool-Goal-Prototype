using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelData", menuName = "InGameConfigs/LevelDataConfig", order = 1)]
public class LevelConfigData : BaseConfig<LevelData>
{
    
}

[System.Serializable]
public class LevelData : IValueKeyConfig
{
    public string key => levelID;

    public string levelID;
    public string sceneToLoad;
    public List<SubLevelData> subLevelData;
}

[System.Serializable]
public class SubLevelData
{
    public string subLevelID;
    public Vector3 playerBallSetPosition;

    [Header("Goal Post Settings")]
    public Vector3 goalPostPosition;
    public Vector3 goalPostRotation;
    public Vector3 goalpostScale;

    [Header("Camera And Lighting Settings")]
    public Vector3 cameraPositon;
    public Vector3 cameraRotation;
    public float cameraFOV;
}
