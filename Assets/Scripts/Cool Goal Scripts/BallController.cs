using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] private float ballSpeed;
    [SerializeField] private MeshRenderer ballMesh;
    [SerializeField] private TrailRenderer ballTrailRenderer;
    [SerializeField] private Transform ballHitVFXSpawnPoint;
    [SerializeField] private ParticleSystem hitVFXToSpawn;
    [SerializeField] private ParticleSystem goalHitVFXToSpawn;

    private (Vector3, Vector3, Vector3, Vector3) bezierPointToFollow;
    private bool moveTheBall = false;
    private bool executeUpdate = false;
    private float time = 0;

    private void Start()
    {
        PlayerShootCurveController.OnFinalShot += OnFinalShot;
    }

    private void OnDestroy()
    {
        PlayerShootCurveController.OnFinalShot -= OnFinalShot;
    }

    private void OnFinalShot((Vector3, Vector3, Vector3, Vector3) bezierPointSet)
    {
        bezierPointToFollow = bezierPointSet;
        StartCoroutine(ShootTheBall());
    }

    private IEnumerator ShootTheBall()
    {
        executeUpdate = true;
        yield return new WaitForSeconds(0.6f);
        ParticleSystem spawnedVFX = Instantiate(hitVFXToSpawn, ballHitVFXSpawnPoint.position, Quaternion.identity);
        moveTheBall = true;
    }

    private int currentHitColliderLength = 0;

    private void Update()
    {
        if (!executeUpdate)
            return;

        Collider[] hitColliders = Physics.OverlapSphere(transform.position, 0.13f);
        HandleCollisionEffectsOnCollidedObjects(hitColliders);

        if (hitColliders.Length > 1)
        {
            moveTheBall = false;
            GetComponent<Rigidbody>().isKinematic = false;
        }

        if(moveTheBall)
        {
            if (time >= 1f)
            {
                moveTheBall = false;
                GetComponent<Rigidbody>().isKinematic = false;
                return;
            }

            GetComponent<Rigidbody>().MovePosition(BezierCurve.GetBezierPoint(bezierPointToFollow.Item1, bezierPointToFollow.Item3, bezierPointToFollow.Item4, bezierPointToFollow.Item2, time));
            time += Time.deltaTime * ballSpeed;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (GameStateController.Instance.CurrentState.GetType() == typeof(GameSubLevelProgress))
        {
            if (other.tag == "WinCollider")
            {
                ParticleSystem hitPS = Instantiate(goalHitVFXToSpawn, transform.position, Quaternion.identity);
                hitPS.Play();
                ballMesh.enabled = false;
                ballTrailRenderer.enabled = false;
            }

            other.GetComponent<IBallTriggerEnterReactor>().OnBallTriggerEnter(other.ClosestPoint(transform.position));
        }
    }

    private void HandleCollisionEffectsOnCollidedObjects(Collider[] hitColliders)
    {
        if (currentHitColliderLength != hitColliders.Length)
        {
            if (hitColliders[0].transform.GetComponent<IBallCollidable>() != null)
                hitColliders[0].transform.GetComponent<IBallCollidable>().OnBallCollision(hitColliders[0].ClosestPoint(transform.position));

            currentHitColliderLength = hitColliders.Length;
        }
    }
    
    public void ResetBallOnLevelSubLevelComplete()
    {
        StartCoroutine(ResetBallIEnunm());
    }

    private IEnumerator ResetBallIEnunm()
    {
        time = 0;
        executeUpdate = false;
        moveTheBall = false;

        float resetRigidbodyTime = 2f;
        while(resetRigidbodyTime > 0)
        {
            resetRigidbodyTime -= Time.deltaTime;
            GetComponent<Rigidbody>().isKinematic = true;
            ballTrailRenderer.enabled = true;
            ballMesh.enabled = true;
            yield return null;
        }
    }
}
