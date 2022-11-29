using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCStraightLine : INPCFormationShape
{
    public void FormShape(Vector3 initialPoint, GameObject[] characters)
    {
        foreach (var item in characters)
        {
            item.transform.position = initialPoint;
            initialPoint += new Vector3(-0.70f, 0, 0);
        }
    }
}
