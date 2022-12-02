using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] private bool isTesting;
    [SerializeField] private string currentLevelIDToLoad;

    private static int currentLevelIndex;
    private static string currentLevelID;

    public static int CurrentLevelIndex => currentLevelIndex;

    public static string CurrentLevelID => currentLevelID;

    public static LevelLoader Instance;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this);

        DontDestroyOnLoad(this);
    }

    void Start()
    {
        //Load from playerPrefs!!
        currentLevelIndex = 0;

        currentLevelID = GetLevelID(currentLevelIndex);

        if(isTesting)
        {
            LoadLevel(currentLevelIDToLoad);
        }
        else
        {
            LoadLevel(currentLevelID);
        }

    }

    public void LoadLevel(string levelID)
    {
        Dictionary<string, LevelData> levelData = LevelConfigData.data;

        string sceneToLoad = levelData[levelID].sceneToLoad;
        SceneManager.LoadScene(sceneToLoad);

        currentLevelID = levelID;
        currentLevelIndex = levelData.Values.ToList().IndexOf(levelData[levelID]);
    }

    public void LoadLevel(int levelIndexToLoad)
    {
        Dictionary<string, LevelData> levelData = LevelConfigData.data;

        int index = 0;
        foreach (var item in levelData)
        {
            if(index == levelIndexToLoad)
            {
                string sceneToLoad = item.Value.sceneToLoad;
                SceneManager.LoadScene(sceneToLoad);

                currentLevelID = item.Key;
                currentLevelIndex = index;

                break;
            }

            index += 1;
        }
    }

    private string GetLevelID(int currentLevelIndex)
    {
        Dictionary<string, LevelData> levelData = LevelConfigData.data;

        int index = 0;
        foreach (var item in levelData)
        {
            if (index == currentLevelIndex)
            {
                return item.Key;
            }

            index += 1;
        }

        return string.Empty;
    }
}
