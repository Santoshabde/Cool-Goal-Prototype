using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Obstrucle_ChristmasTree : MonoBehaviour, IBallCollidable
{
    [Header("Tree Animation Variables")]
    [SerializeField] private Vector3 finalTreeRotation_1;
    [SerializeField] private Vector3 finalTreeRotation_2;
    [SerializeField] private int animationEventsCount;
    [SerializeField, Range(0, 1)] private float singleEventTweenTime; 

    public void OnBallCollision()
    {
        SwayTreeAnimation();
    }

    private void SwayTreeAnimation()
    {
        Sequence treeAnimationSequence = DOTween.Sequence();
        for (int i = 0; i < animationEventsCount; i++)
        {
            treeAnimationSequence.Append(transform.DORotate(finalTreeRotation_1, singleEventTweenTime));
            treeAnimationSequence.Append(transform.DORotate(finalTreeRotation_2, singleEventTweenTime));
        }  

        treeAnimationSequence.Append(transform.DORotate(new Vector3(0, 0, 0), singleEventTweenTime));
    }
}
