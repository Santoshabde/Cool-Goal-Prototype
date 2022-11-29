using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerState_Shoot : BaseState
{
    private PlayerStateController playerStateController;

    public PlayerState_Shoot(PlayerStateController playerStateController)
    {
        this.playerStateController = playerStateController;
    }

    public override void Enter()
    {
        playerStateController.StartCoroutine(PlayKickAnimation());
    }

    public override void Exit()
    {
        
    }

    public override void Tick(float deltaTime)
    {
        
    }

    private IEnumerator PlayKickAnimation()
    {
        playerStateController.PlayerAnimator.CrossFade("Kick", 0);
        yield return null;

        float animationTime = playerStateController.PlayerAnimator.GetCurrentAnimatorStateInfo(0).length;
        yield return new WaitForSeconds(animationTime);

        playerStateController.transform.DORotate(Vector3.zero, 0.3f);
    }
}
