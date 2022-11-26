using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateMachine : MonoBehaviour
{
    [SerializeField] private string currentString;

    protected BaseState currentState = null;
    protected BaseState previousState = null;
    public BaseState CurrentState => currentState;
    public BaseState PreviousState => previousState;

    private bool executeState = true;

    private void Update()
    {
        currentString = currentState?.ToString();

        if (executeState)
            currentState?.Tick(Time.deltaTime);
    }

    public void SwitchState(BaseState newState)
    {
        executeState = false;

        currentState?.Exit();
        previousState = CurrentState;
        currentState = newState;
        currentState?.Enter();

        executeState = true;
    }
}
