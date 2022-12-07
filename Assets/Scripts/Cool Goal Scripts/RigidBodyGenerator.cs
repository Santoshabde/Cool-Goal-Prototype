using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidBodyGenerator : MonoBehaviour
{
    [SerializeField] private List<RigidBodyMovement> randomBodies;
    [SerializeField] private float minGenerationTimeGap;
    [SerializeField] private float maxGenerationTimeGap;

    private void Awake()
    {
        StartCoroutine(StartGeneration());
    }

    private IEnumerator StartGeneration()
    {
        while (true)
        {
            //TODO:Santosh Need Object pooling Here
            GameObject generated = Instantiate(randomBodies[Random.Range(0, randomBodies.Count)].gameObject, transform.position, Quaternion.identity);
            generated.transform.forward = transform.forward;

            yield return new WaitForSeconds(Random.Range(minGenerationTimeGap, maxGenerationTimeGap));
        }
    }
}
