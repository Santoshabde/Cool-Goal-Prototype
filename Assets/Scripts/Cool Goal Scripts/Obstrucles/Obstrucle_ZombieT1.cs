using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstrucle_ZombieT1 : MonoBehaviour, IBallCollidable
{
    [SerializeField] private Animator animator;
    [SerializeField] private Rigidbody rb;

    public void OnBallCollision(Vector3 contactPointPosition)
    {
        rb.isKinematic = false;
        animator.enabled = false;
    }
}
