using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMainLevelComplete : BaseState
{
    private GameStateController gameStateController;
    public GameMainLevelComplete(GameStateController gameStateController)
    {
        this.gameStateController = gameStateController;
    }

    public override void Enter()
    {
        UIManager.Instance.OpenDialog<LevelCompletionDialog>();
    }

    public override void Exit()
    {
        
    }

    public override void Tick(float deltaTime)
    {
        
    }
}
