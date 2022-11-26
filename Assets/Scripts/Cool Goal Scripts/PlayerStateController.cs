using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateController : StateMachine
{
    [SerializeField] private Animator playerAnimator;

    public Animator PlayerAnimator => playerAnimator;

    private void Start()
    {
        SwitchState(new PlayerState_Idle(this));
    }
}
