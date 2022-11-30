using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseNPCFormation : MonoBehaviour, IBallCollidable
{
    [SerializeField] private int numberOfCharacters;
    [SerializeField] private GameObject NPCCharacterPrefab;
    [SerializeField] private float characterMovementSpeed;
    [SerializeField] private string animationToPlay;
    [SerializeField] private List<Transform> idleRoamPoints;

    private int currentPositionCount = 0;
    private INPCFormationShape shape;
    private void Start()
    {
        shape = new NPCStraightLine();

        GameObject[] characters = new GameObject[numberOfCharacters];
        for (int i = 0; i < numberOfCharacters; i++)
        {
            GameObject character = Instantiate(NPCCharacterPrefab);
            character.transform.SetParent(this.transform);
            character.GetComponent<Animator>().CrossFade(animationToPlay, 0);
            characters[i] = character;
        }

        shape.FormShape(transform.position, characters);   
    }

    private void Update()
    {
        if ((idleRoamPoints[currentPositionCount].position - transform.position).magnitude < 0.1f)
            currentPositionCount = ((currentPositionCount + 1) % (idleRoamPoints.Count));

        transform.position += (idleRoamPoints[currentPositionCount].position - transform.position).normalized * Time.deltaTime * characterMovementSpeed;
    }

    public void OnBallCollision(Vector3 contactPointPosition)
    {
        //Activate the ragdoll
        transform.gameObject.SetActive(false);
    }
}
