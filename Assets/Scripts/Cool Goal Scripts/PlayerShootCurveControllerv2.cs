using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootCurveControllerv2 : MonoBehaviour
{
    [SerializeReference] private Transform testPoint;
    [SerializeField] private Transform initialBallPosition;

    private GoalPost goalPostInLevel;
    private AnimationCurve goalAnimationCurve;

    private void Start()
    {
        FindGoalPostInGame();
    }

    private void Update()
    {
           
        testPoint.position = new Vector3(goalAnimationCurve.Evaluate(InputController.Instance.DragAmount), 0.5f, -4f);
    }

    private void FindGoalPostInGame()
    {
        goalPostInLevel = FindObjectOfType<GoalPost>();
        goalAnimationCurve = goalPostInLevel.SetGoalPostGoalCurve();
    }
}
