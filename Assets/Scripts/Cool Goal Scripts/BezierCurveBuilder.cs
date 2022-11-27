using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BezierCurveBuilderType
{
    DottedPath,
    LineRenderer
}

public class BezierCurveBuilder : MonoBehaviour
{
    [SerializeField] private GameObject bezierCurveIndicator;
    [SerializeField] private LineRenderer bezierCurveLineRenderer;
    [SerializeField] private int maxIndicatorObjects;
    [SerializeField] private float bezierCurveSampleTimeGap;

    private List<GameObject> bezierCurveIndicatorObjectsList = null;

    private void Awake()
    {
        bezierCurveIndicatorObjectsList = null;
    }

    public void BuildBezierCurve(Vector3 p0, Vector3 p1, Vector3 t0, Vector3 t1, BezierCurveBuilderType curveType)
    {
        List<ShapePointAndDirection> equiDistancePoints = BezierCurve.GetAllEquiDistancePointsOnBezierCurve(p0, t0, t1, p1, 0.1f);
        switch (curveType)
        {
            case BezierCurveBuilderType.DottedPath:
                if (bezierCurveIndicatorObjectsList == null)
                {
                    bezierCurveIndicatorObjectsList = new List<GameObject>();
                    for (int i = 0; i < maxIndicatorObjects; i++)
                    {
                        GameObject obj = Instantiate(bezierCurveIndicator);
                        obj.SetActive(false);
                        bezierCurveIndicatorObjectsList.Add(obj);
                    }
                }

                float t = 0;
                bezierCurveIndicatorObjectsList.ForEach(obj => obj.SetActive(false));
                foreach (var item in bezierCurveIndicatorObjectsList)
                {
                    item.SetActive(true);
                    item.transform.position = BezierCurve.GetBezierPoint(p0, t0, t1, p1, t);
                    t += bezierCurveSampleTimeGap;
                }
                break;
            case BezierCurveBuilderType.LineRenderer:

                if(bezierCurveIndicatorObjectsList != null)
                {
                    bezierCurveIndicatorObjectsList.ForEach(t => Destroy(t));
                    bezierCurveIndicatorObjectsList.Clear();
                    bezierCurveIndicatorObjectsList = null;
                }

                bezierCurveLineRenderer.positionCount = equiDistancePoints.Count;
                int index = 0;
                foreach (var item in equiDistancePoints)
                {
                    bezierCurveLineRenderer.SetPosition(index, item.point);
                    index++;
                }

                break;
            default:
                break;
        }  
    }
}
