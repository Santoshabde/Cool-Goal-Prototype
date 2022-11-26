using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState_Idle : BaseState
{
    private PlayerStateController playerStateController;
    
    public PlayerState_Idle(PlayerStateController playerStateController)
    {
        this.playerStateController = playerStateController;
    }

    public override void Enter()
    {
        InputController.Instance.ShootActionActivated += OnPlayerShoot;
    }

    public override void Exit()
    {
        InputController.Instance.ShootActionActivated -= OnPlayerShoot;
    }

    public override void Tick(float deltaTime)
    {
        
    }

    private void OnPlayerShoot()
    {
        playerStateController.SwitchState(new PlayerState_Shoot(playerStateController));
    }
}
