using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] private float ballSpeed;

    private (Vector3, Vector3, Vector3, Vector3) bezierPointToFollow;
    private bool moveTheBall = false;
    private float time = 0;
    List<ShapePointAndDirection> totalBazierCurvePoints;

    private void Start()
    {
        PlayerShootCurveController.OnFinalShot += OnFinalShot;
    }

    private void OnFinalShot((Vector3, Vector3, Vector3, Vector3) bezierPointSet)
    {
        bezierPointToFollow = bezierPointSet;
        totalBazierCurvePoints = BezierCurve.GetAllBazierPoints(bezierPointSet.Item1, bezierPointSet.Item3, bezierPointSet.Item4, bezierPointSet.Item2);
        moveTheBall = true;
    }

    private void FixedUpdate()
    {
        if(moveTheBall)
        {
            Vector3 nearestPoint = FindNearestPoint();
            //GetComponent<Rigidbody>().AddForce(BezierCurve.GetBazierTangent(bezierPointToFollow.Item1, bezierPointToFollow.Item3, bezierPointToFollow.Item4, bezierPointToFollow.Item2, time) * 30);
            GetComponent<Rigidbody>().AddForce((nearestPoint - transform.position) * 150);

            if(nearestPoint == totalBazierCurvePoints[totalBazierCurvePoints.Count - 1].point)
            {
                moveTheBall = false;
            }
        }
    }

    private Vector3 FindNearestPoint()
    {
        Vector3 nearestPoint = Vector3.zero;

        float shortestDistance = 1000f;

        int i = 0;
        foreach (var item in totalBazierCurvePoints)
        {
            if(i < 2)
            {
                i++;
                continue;
            }

            if((item.point - transform.position).magnitude < shortestDistance)
            {
                shortestDistance = (item.point - transform.position).magnitude;
                nearestPoint = item.point;
            }
        }

        return nearestPoint;
    }
}
