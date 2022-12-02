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
        //Had to give some delay avoidoing race conditons. Need to find a proper solution
        gameStateController.StartCoroutine(UpdateHUD());
        gameStateController.InputController.BlockInput(false);
        gameStateController.SwitchState(new GameSubLevelProgress(gameStateController));
    }

    public override void Exit()
    {
        
    }

    public override void Tick(float deltaTime)
    {
        
    }

    IEnumerator UpdateHUD()
    {
        yield return new WaitForSeconds(0.2f);
        HUDController.Instance.UpdateLevelInfoHUD((LevelLoader.CurrentLevelIndex + 1).ToString(), (LevelLoader.CurrentLevelIndex + 2).ToString(), SubLevelLoader.nextSubLevelIndex);
    }
}
