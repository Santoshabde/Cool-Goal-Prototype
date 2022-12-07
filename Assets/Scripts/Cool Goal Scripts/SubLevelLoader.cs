using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubLevelLoader : MonoBehaviour
{
    private Vector3 LOCAL_BALL_POSITION = new Vector3(0.164169f, 0.16f, 1.011066f);
    private Vector3 LOCAL_PLAYER_POSITION = Vector3.zero;

    [SerializeField] private bool testSubLevel;
    [SerializeField] private string subLevelIdToTest;

    [SerializeField] private GameObject playerBallSet;
    [SerializeField] private PlayerStateController player;
    [SerializeField] private BallController ball;
    [SerializeField] private GoalPost goalPost;
    [SerializeField] private Camera mainCamera;

    [SerializeField] private List<SubLevel> subLevelData;

    public static int nextSubLevelIndex = 0;
    public static string currentSubLevelID = "";

    public void LoadSubLevel()
    {
        SubLevelData subLevelData;
        if (testSubLevel)
        {
            currentSubLevelID = subLevelIdToTest;
            subLevelData = LevelConfigData.data[LevelLoader.CurrentLevelID].subLevelData.Find(t => t.subLevelID == currentSubLevelID);
            nextSubLevelIndex = LevelConfigData.data[LevelLoader.CurrentLevelID].subLevelData.IndexOf(subLevelData);
        }
        else
        {
            //Always first sublevel-level is picked by default
            subLevelData = LevelConfigData.data[LevelLoader.CurrentLevelID].subLevelData[nextSubLevelIndex];
            currentSubLevelID = subLevelData.subLevelID;
        }

        PrepareSubLevel(subLevelData);
    }

    private void PrepareSubLevel(int subLevelIndex)
    {
        SubLevelData subLevelData;
        subLevelData = LevelConfigData.data[LevelLoader.CurrentLevelID].subLevelData[subLevelIndex];

        PrepareSubLevel(subLevelData);
    }

    private void PrepareSubLevel(SubLevelData data)
    {
        if (data == null)
            return;

        ball.ResetBallOnLevelSubLevelComplete();
        subLevelData.ForEach(t => t.subLevel.SetActive(false));

        player.SwitchState(new PlayerState_Idle(player));
        playerBallSet.transform.position = data.playerBallSetPosition;
        goalPost.transform.position = data.goalPostPosition;
        goalPost.transform.rotation = Quaternion.Euler(data.goalPostRotation);

        player.transform.localPosition = LOCAL_PLAYER_POSITION;
        ball.transform.localPosition = LOCAL_BALL_POSITION;

        mainCamera.transform.position = data.cameraPositon;
        mainCamera.transform.rotation = Quaternion.Euler(data.cameraRotation);
        mainCamera.fieldOfView = data.cameraFOV;

        subLevelData.Find(t => t.subLevelID == data.subLevelID).subLevel.SetActive(true);
    }

    public bool IncrementSubLevel()
    {
        bool hasNextSubLevel = true;
        nextSubLevelIndex += 1;

        if(nextSubLevelIndex >= subLevelData.Count)
        {
            //Level Completed
            hasNextSubLevel = false;
            nextSubLevelIndex = 0;
        }

        return hasNextSubLevel;
    }
}

[System.Serializable]
public class SubLevel
{
    public string subLevelID;
    public GameObject subLevel;
}
