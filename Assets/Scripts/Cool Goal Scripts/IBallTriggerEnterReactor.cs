using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBallTriggerEnterReactor
{
    void OnBallTriggerEnter(Vector3 contactPoint);
}
