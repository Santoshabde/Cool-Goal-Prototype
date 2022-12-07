using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSubLevelProgress : BaseState
{
    private bool trackProgress = false;
    private float currentBallTimeStamp = 0;

    private GameStateController gameStateController;
    public GameSubLevelProgress(GameStateController gameStateController)
    {
        this.gameStateController = gameStateController;
    }

    public override void Enter()
    {
        gameStateController.InputController.ShootActionActivated += ShootActionActivated;
        PlayerShootCurveController.OnFinalShot += OnFinalShot;
    }

    private void OnFinalShot((Vector3, Vector3, Vector3, Vector3) obj)
    {
        trackProgress = true;
        currentBallTimeStamp = 0;
    }

    public override void Exit()
    {
        gameStateController.InputController.ShootActionActivated -= ShootActionActivated;
        PlayerShootCurveController.OnFinalShot -= OnFinalShot;

        trackProgress = false;
        currentBallTimeStamp = 0;
    }

    public override void Tick(float deltaTime)
    {
        if(trackProgress)
        {
            currentBallTimeStamp += Time.deltaTime;
            if(currentBallTimeStamp > 4f)
            {
                UIManager.Instance.OpenDialog<LevelFailedDialog>();
                SubLevelLoader.nextSubLevelIndex = 0;
                gameStateController.SwitchState(new GameSubLevelFail(gameStateController));
            }
        }
    }

    private void ShootActionActivated()
    {
        gameStateController.InputController.BlockInput(true);
    }
}
