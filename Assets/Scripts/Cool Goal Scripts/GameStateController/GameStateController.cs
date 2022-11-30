using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateController : StateMachine
{
    [SerializeField] private InputController inputController;
    [SerializeField] private SubLevelLoader subLevelLoader;

    public InputController InputController => inputController;
    public SubLevelLoader SubLevelLoader => subLevelLoader;

    public static GameStateController Instance;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this);

        SwitchState(new GameSubLevelStart(this));
    }
}
