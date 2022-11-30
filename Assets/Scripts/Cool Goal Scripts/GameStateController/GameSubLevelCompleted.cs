using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSubLevelCompleted : BaseState
{
    private GameStateController gameStateController;
    public GameSubLevelCompleted(GameStateController gameStateController)
    {
        this.gameStateController = gameStateController;
    }

    public override void Enter()
    {
        //May be play some effects
        //

        gameStateController.StartCoroutine(SubLevelCompletedAction());
    }

    public override void Exit()
    {
        
    }

    public override void Tick(float deltaTime)
    {
        
    }

    IEnumerator SubLevelCompletedAction()
    {
        yield return new WaitForSeconds(3f);

        //If level completed
        if (!gameStateController.SubLevelLoader.IncrementSubLevel())
        {
            gameStateController.SwitchState(new GameMainLevelComplete(gameStateController));
        }
        //If sublevel completed
        else
        {
            gameStateController.SwitchState(new GameSubLevelStart(gameStateController));
        }

        yield return new WaitForSeconds(0.5f);

        gameStateController.InputController.BlockInput(false);
    }
}
