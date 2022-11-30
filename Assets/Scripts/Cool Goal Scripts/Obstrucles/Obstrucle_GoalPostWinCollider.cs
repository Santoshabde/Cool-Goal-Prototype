using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstrucle_GoalPostWinCollider : MonoBehaviour, IBallCollidable
{
    public static Action OnGoalScore;

    public void OnBallCollision()
    {
        OnGoalScore?.Invoke();
        GameStateController.Instance.SwitchState(
            new GameSubLevelCompleted(GameStateController.Instance));
    }
}
