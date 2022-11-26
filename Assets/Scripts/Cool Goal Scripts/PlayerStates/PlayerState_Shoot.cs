using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState_Shoot : BaseState
{
    private PlayerStateController playerStateController;

    public PlayerState_Shoot(PlayerStateController playerStateController)
    {
        this.playerStateController = playerStateController;
    }

    public override void Enter()
    {
        playerStateController.PlayerAnimator.CrossFade("Kick",0);
    }

    public override void Exit()
    {
        
    }

    public override void Tick(float deltaTime)
    {
        
    }
}
