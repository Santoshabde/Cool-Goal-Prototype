using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] private float ballSpeed;

    private (Vector3, Vector3, Vector3, Vector3) bezierPointToFollow;
    private bool moveTheBall = false;
    private float time = 0;

    private void Start()
    {
        PlayerShootCurveController.OnFinalShot += OnFinalShot;
    }

    private void OnFinalShot((Vector3, Vector3, Vector3, Vector3) bezierPointSet)
    {
        bezierPointToFollow = bezierPointSet;
        StartCoroutine(ShootTheBall());
    }

    private IEnumerator ShootTheBall()
    {
        yield return new WaitForSeconds(0.6f);
        moveTheBall = true;
    }

    private void Update()
    {
        if(moveTheBall)
        {
            if (time >= 1f)
            {
                moveTheBall = false;
                GetComponent<Rigidbody>().isKinematic = false;
                //GetComponent<Rigidbody>().velocity = (BezierCurve.GetBazierTangent(bezierPointToFollow.Item1, bezierPointToFollow.Item3, bezierPointToFollow.Item4, bezierPointToFollow.Item2, 0.95f)).normalized * speed;
                return;
            }

            GetComponent<Rigidbody>().MovePosition(BezierCurve.GetBezierPoint(bezierPointToFollow.Item1, bezierPointToFollow.Item3, bezierPointToFollow.Item4, bezierPointToFollow.Item2, time));
            time += Time.deltaTime * ballSpeed;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        moveTheBall = false;
        GetComponent<Rigidbody>().isKinematic = false;
    }
}
