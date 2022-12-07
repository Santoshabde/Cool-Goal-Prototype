using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidBodyMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    [SerializeField] private float secondsToDestroyAfter;

    private IEnumerator Start()
    {
        //TODO:Santosh Need Object pooling Here
        yield return new WaitForSecondsRealtime(secondsToDestroyAfter);
        Destroy(this.gameObject);
    }

    void Update()
    {
        transform.position += transform.forward * Time.deltaTime * movementSpeed;
    }
}
