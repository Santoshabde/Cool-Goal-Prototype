using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingScreenAnimation : MonoBehaviour
{
    [SerializeField] private GameObject loadingScreenImage;
    [SerializeField] private float rotationSpeed;

    void Update()
    {
        loadingScreenImage.transform.Rotate(0, 0, Time.deltaTime * rotationSpeed);
    }
}
