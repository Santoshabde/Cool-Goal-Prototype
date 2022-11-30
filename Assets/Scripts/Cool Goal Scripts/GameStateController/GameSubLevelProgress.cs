using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSubLevelProgress : BaseState
{
    private GameStateController gameStateController;
    public GameSubLevelProgress(GameStateController gameStateController)
    {
        this.gameStateController = gameStateController;
    }

    public override void Enter()
    {
        gameStateController.InputController.ShootActionActivated += ShootActionActivated;
    }

    public override void Exit()
    {
        gameStateController.InputController.ShootActionActivated -= ShootActionActivated;
    }

    public override void Tick(float deltaTime)
    {
        
    }

    private void ShootActionActivated()
    {
        gameStateController.InputController.BlockInput(true);
    }
}
