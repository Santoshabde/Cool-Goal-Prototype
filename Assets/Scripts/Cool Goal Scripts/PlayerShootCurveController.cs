using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerShootCurveController : MonoBehaviour
{
    [SerializeField] private float curveDragCofficient_source;
    [SerializeField] private float curveDragCofficient_target;
    [SerializeField] private Transform initialBallPosition;
    [SerializeField] private BezierCurveBuilder bezierCurveBuilder;

    private GoalPost goalPostInLevel;
    private AnimationCurve goalAnimationCurve;
    private Vector3 initialShootPosition;
    private Vector3 finalShotPosition;
    private Vector3 bezierCurve_Tangent1;
    private Vector3 bezierCurve_Tangent2;

    public static Action<(Vector3, Vector3, Vector3, Vector3)> OnFinalShot;

    private void Start()
    {
        FindGoalPostInGame();
        InputController.Instance.ShootActionActivated += OnShoot;
    }

    private void OnDestroy()
    {
        InputController.Instance.ShootActionActivated -= OnShoot;
    }

    private void OnShoot()
    {
        OnFinalShot.Invoke(GetBezierCurveInstance());
    }

    private void Update()
    {
        BuildBezierCurveShootPath();
    }

    public (Vector3 p0, Vector3 p1, Vector3 t0, Vector3 t1) GetBezierCurveInstance()
    {
        return (initialShootPosition, finalShotPosition, bezierCurve_Tangent1, bezierCurve_Tangent2);
    }

    private void FindGoalPostInGame()
    {
        goalPostInLevel = FindObjectOfType<GoalPost>();
        goalAnimationCurve = goalPostInLevel.SetGoalPostGoalCurve();
    }

    private void BuildBezierCurveShootPath()
    {
        initialShootPosition = initialBallPosition.position;
        finalShotPosition = new Vector3(goalAnimationCurve.Evaluate(InputController.Instance.DragAmount), 0.5f, -4f);
        bezierCurve_Tangent1 = new Vector3(initialShootPosition.x + (curveDragCofficient_source * InputController.Instance.DragAmount), initialShootPosition.y, initialShootPosition.z);
        if (InputController.Instance.DragAmount <= goalPostInLevel.DragAmountToReachMax)
        {
            bezierCurve_Tangent2 = new Vector3(finalShotPosition.x + (curveDragCofficient_target * InputController.Instance.DragAmount), finalShotPosition.y, finalShotPosition.z);
        }

        bezierCurveBuilder.BuildBezierCurve(initialShootPosition, finalShotPosition, bezierCurve_Tangent1, bezierCurve_Tangent2, BezierCurveBuilderType.LineRenderer);
    }


    #region Debug Region
    private void OnDrawGizmos()
    {
        Handles.DrawBezier(initialShootPosition, finalShotPosition, bezierCurve_Tangent1, bezierCurve_Tangent2, Color.red, null, 3f);

      /*  Gizmos.color = Color.red;
        foreach (var item in BezierCurve.GetAllBazierPoints(initialShootPosition, bezierCurve_Tangent1, bezierCurve_Tangent2, finalShotPosition))
        {
            Gizmos.DrawSphere(item.point, 0.1f);
        }*/
    }

    #endregion
}
