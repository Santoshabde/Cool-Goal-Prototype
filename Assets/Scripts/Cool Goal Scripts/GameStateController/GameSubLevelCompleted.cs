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
        bool nextSubLevelAvailableInSameLevel = gameStateController.SubLevelLoader.IncrementSubLevel();

        yield return new WaitForSeconds(0.3f);
        UIManager.Instance.DisplayCard<GoalAppreciationCard>();

        yield return new WaitForSeconds(1.5f);

        UIManager.Instance.CloseCard<GoalAppreciationCard>();

        if (nextSubLevelAvailableInSameLevel)
        InGameLevelTransitions.Instance.SubLevelTransition(SubLevelLoader.nextSubLevelIndex + 1);

        yield return new WaitForSeconds(1f);

        //If level completed
        if (!nextSubLevelAvailableInSameLevel)
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
