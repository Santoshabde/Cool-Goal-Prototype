using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBallCollidable
{
    void OnBallCollision(Vector3 contactPointPosition);
}
