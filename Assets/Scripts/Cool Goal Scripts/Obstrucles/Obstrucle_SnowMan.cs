using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstrucle_SnowMan : MonoBehaviour, IBallCollidable
{
    [SerializeField] private List<GameObject> objectsToSeperate;

    public void OnBallCollision(Vector3 contactPointPosition)
    {
        objectsToSeperate.ForEach(t => t.transform.SetParent(GameStateController.Instance.SubLevelLoader.GetCurrentSubLevelParent()));
        foreach (var item in objectsToSeperate)
        {
            Rigidbody rb = item.AddComponent<Rigidbody>();
            rb.mass = 100;
            rb.drag = 10;
            item.AddComponent<SphereCollider>();
            rb.useGravity = true;
        }

        transform.gameObject.SetActive(false);
    }
}
