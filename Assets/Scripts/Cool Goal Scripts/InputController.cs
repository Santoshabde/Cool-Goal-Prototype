using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : SerializedSingleton<InputController>
{
    [SerializeField] private float maxDragAmount;

    private float dragAmount = 0;
    private Vector3 initialPointPosition;

    public float DragAmount => dragAmount;

    public Action ShootActionActivated;
    public Action OnScreenTouchDown;

    private bool blockInput;
    private void Update()
    {
        if (blockInput)
            return;

        if(Input.GetMouseButtonDown(0))
        {
            EventOnMouseDown(Input.mousePosition);
        }
        else if(Input.GetMouseButton(0))
        {
            EventOnMouseDrag(Input.mousePosition);
        }
        else if(Input.GetMouseButtonUp(0))
        {
            EventOnMouseUp(Input.mousePosition);
        }
    }

    private void EventOnMouseDown(Vector3 mousePointPosition)
    {
        OnScreenTouchDown?.Invoke();
        initialPointPosition = mousePointPosition;
        dragAmount = 0;
    }

    private void EventOnMouseUp(Vector3 mousePointPosition)
    {
        ShootActionActivated?.Invoke();
    }

    private void EventOnMouseDrag(Vector3 mousePointPosition)
    {
        dragAmount = (mousePointPosition.x - initialPointPosition.x);
        dragAmount = dragAmount.Clamp01Range(0, maxDragAmount);
    }

    public void BlockInput(bool value)
    {
        blockInput = value;
    }
}
