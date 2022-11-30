using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GoalPost : MonoBehaviour
{
    //Only for testing
    [SerializeField] private AnimationCurve goalCurve;

    [SerializeField] private Material goalMaterial;
    [SerializeField] private float goalPostMaxLength;
    [SerializeField] private float goalPostNearMaxLength;
    [SerializeField] private float dragAmountToReachMax;
    [SerializeField] private List<ParticleSystem> confettiEffects;
    [SerializeField] private ParticleSystem hitConfetti;

    public float DragAmountToReachMax => dragAmountToReachMax;

    private void Awake()
    {
        Obstrucle_GoalPostWinCollider.OnGoalScore += OnGoalVFX;

        goalMaterial.color = new Color(goalMaterial.color.r, goalMaterial.color.g, goalMaterial.color.b, 0f);
    }

    public AnimationCurve SetGoalPostGoalCurve()
    {
        Keyframe origin = new Keyframe(0, 0);
        Keyframe k1_r = new Keyframe(dragAmountToReachMax, goalPostMaxLength);
        Keyframe k2_r = new Keyframe(1, -goalPostNearMaxLength);

        Keyframe k1_l = new Keyframe(-dragAmountToReachMax, -goalPostMaxLength);
        Keyframe k2_l = new Keyframe(-1, +goalPostNearMaxLength);

        goalCurve = new AnimationCurve(new Keyframe[] { origin, k1_r, k2_r, k1_l, k2_l });

        return goalCurve;
    }

    private void OnGoalVFX(Vector3 contactPointPosition)
    {
        goalMaterial.DOColor(new Color(goalMaterial.color.r, goalMaterial.color.g, goalMaterial.color.b, 0.5f), 0.1f).SetLoops(8, LoopType.Yoyo);
        DOTween.Sequence().AppendInterval(0.5f).AppendCallback(() =>
        {
            confettiEffects.ForEach(t => t.Play());
        });
    }
}
