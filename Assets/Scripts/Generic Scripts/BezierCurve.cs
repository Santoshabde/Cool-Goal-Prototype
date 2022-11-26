using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct ShapePointAndDirection
{
    public Vector3 point;
    public Vector3 direction;
}

public class BezierCurve
{
    public static Vector3 GetBezierPoint(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3, float t)
    {
        Vector3 calulatedBazierPoint = Vector3.zero;

        Vector3 p0p1 = Vector3.Lerp(p0, p1, t);
        Vector3 p1p2 = Vector3.Lerp(p1, p2, t);
        Vector3 p2p3 = Vector3.Lerp(p2, p3, t);

        Vector3 d = Vector3.Lerp(p0p1, p1p2, t);
        Vector3 e = Vector3.Lerp(p1p2, p2p3, t);

        calulatedBazierPoint = Vector3.Lerp(d, e, t);

        return calulatedBazierPoint;
    }

    public static Vector3 GetBazierTangent(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3, float t)
    {
        Vector3 p0p1 = Vector3.Lerp(p0, p1, t);
        Vector3 p1p2 = Vector3.Lerp(p1, p2, t);
        Vector3 p2p3 = Vector3.Lerp(p2, p3, t);

        Vector3 d = Vector3.Lerp(p0p1, p1p2, t);
        Vector3 e = Vector3.Lerp(p1p2, p2p3, t);

        Vector3 tangent = (e - d).normalized;

        return tangent;
    }

    public static List<ShapePointAndDirection> GetAllBazierPoints(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3)
    {
        List<ShapePointAndDirection> totalBazierCurvePoints = new List<ShapePointAndDirection>();

            float i = 0;
            totalBazierCurvePoints.Add(new ShapePointAndDirection()
            {
                point = p0,
                direction = GetBazierTangent(p0, p1, p2, p3, i)
            });

            Vector3 currentPoint = p0;
            while (i < 1)
            {
                Vector3 nextPoint = GetBezierPoint(p0, p1, p2, p3, i);
                Vector3 nextDirection = GetBazierTangent(p0, p1, p2, p3, i);

                if (Vector3.Distance(currentPoint, nextPoint) >= 0.5f)
                {
                    totalBazierCurvePoints.Add(new ShapePointAndDirection() { point = nextPoint, direction = nextDirection });
                    currentPoint = nextPoint;
                }

                i += 0.01f;
            }

        return totalBazierCurvePoints;
    }
}
