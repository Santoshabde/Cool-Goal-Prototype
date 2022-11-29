using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] private bool isTesting;
    [SerializeField] private string currentLevelToLoad;


    void Start()
    {
        if (isTesting)
        {
            Dictionary<string, LevelData> levelData = LevelConfigData.data;

            foreach (var data in levelData)
            {
                if(data.Value.sceneToLoad == currentLevelToLoad)
                {
                    SceneManager.LoadScene(currentLevelToLoad);
                    break;
                }
            }
        }
    }
}
