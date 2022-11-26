using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BezierCurveBuilder : MonoBehaviour
{
    [SerializeField] private GameObject bezierCurveIndicator;
    [SerializeField] private int maxIndicatorObjects;
    [SerializeField] private float bezierCurveSampleTimeGap;

    private List<GameObject> bezierCurveIndicatorList = null;

    private void Awake()
    {
        bezierCurveIndicatorList = null;
    }

    public void BuildBezierCurve(Vector3 p0, Vector3 p1, Vector3 t0, Vector3 t1)
    {
        if(bezierCurveIndicatorList == null)
        {
            bezierCurveIndicatorList = new List<GameObject>();
            for (int i = 0; i < maxIndicatorObjects; i++)
            {
                GameObject obj = Instantiate(bezierCurveIndicator);
                obj.SetActive(false);
                bezierCurveIndicatorList.Add(obj);
            }
        }

        float t = 0;
        bezierCurveIndicatorList.ForEach(obj => obj.SetActive(false));
        foreach (var item in bezierCurveIndicatorList)
        {
            item.SetActive(true);
            item.transform.position = BezierCurve.GetBezierPoint(p0, t0, t1, p1, t);
            t += bezierCurveSampleTimeGap;
        }
    }
}
