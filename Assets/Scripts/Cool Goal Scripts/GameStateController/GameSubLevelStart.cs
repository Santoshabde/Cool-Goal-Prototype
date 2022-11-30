using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSubLevelStart : BaseState
{
    private GameStateController gameStateController;
    public GameSubLevelStart(GameStateController gameStateController)
    {
        this.gameStateController = gameStateController;
    }

    public override void Enter()
    {
        gameStateController.SubLevelLoader.LoadSubLevel();
        gameStateController.InputController.BlockInput(false);
        gameStateController.SwitchState(new GameSubLevelProgress(gameStateController));
    }

    public override void Exit()
    {
        
    }

    public override void Tick(float deltaTime)
    {
        
    }
}
