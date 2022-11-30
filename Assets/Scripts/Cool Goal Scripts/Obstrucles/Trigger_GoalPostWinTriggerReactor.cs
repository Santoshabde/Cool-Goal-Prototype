using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_GoalPostWinTriggerReactor : MonoBehaviour, IBallTriggerEnterReactor
{
    public static Action<Vector3> OnGoalScore;

    public void OnBallTriggerEnter(Vector3 contactPoint)
    {
        OnGoalScore?.Invoke(contactPoint);
        GameStateController.Instance.SwitchState(
            new GameSubLevelCompleted(GameStateController.Instance));
    }
}
