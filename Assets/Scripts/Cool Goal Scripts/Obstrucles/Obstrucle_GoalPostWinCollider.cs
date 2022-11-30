using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstrucle_GoalPostWinCollider : MonoBehaviour
{
    public static Action<Vector3> OnGoalScore;

    public void OnBallCollision(Vector3 contactPointPosition)
    {
        OnGoalScore?.Invoke(contactPointPosition);
        GameStateController.Instance.SwitchState(
            new GameSubLevelCompleted(GameStateController.Instance));
    }
}
