using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface INPCFormationShape
{
    void FormShape(Vector3 initialPoint, GameObject[] characters);
}
