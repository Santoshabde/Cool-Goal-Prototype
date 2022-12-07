using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstrucles_Movement : MonoBehaviour
{
    [SerializeField] private List<Transform> idleRoamPoints;
    [SerializeField] private float movementSpeed;

    private int currentPositionCount = 0;
    private void Update()
    {
        if ((idleRoamPoints[currentPositionCount].position - transform.position).magnitude < 0.1f)
            currentPositionCount = ((currentPositionCount + 1) % (idleRoamPoints.Count));

        transform.position += (idleRoamPoints[currentPositionCount].position - transform.position).normalized * Time.deltaTime * movementSpeed;
    }
}
