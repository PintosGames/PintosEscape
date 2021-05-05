using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Core;

public class PlayerInputHandler : MonoBehaviour
{
    public Vector2 RawMovementInput { get; private set; }
    public int NormInputX { get; private set; }
    public int NormInputY { get; private set; }
    public bool JumpInput { get; private set; }
    public bool JumpInputStop { get; private set; }
    public bool InteractInput;
    public bool PauseInput;

    [SerializeField]
    private float inputHoldTime = 0.2f;

    private float jumpInputStartTime;

    private void Update()
    {
        CheckJumpInputHoldTime();
    }

    public void OnMoveInput(InputAction.CallbackContext context)
    {
        RawMovementInput = context.ReadValue<Vector2>();

        NormInputX = (int)(RawMovementInput * Vector2.right).normalized.x;
        NormInputY = (int)(RawMovementInput * Vector2.up).normalized.y;

        Debug.Log("move");
    }

    public void OnJumpInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            JumpInput = true;
            JumpInputStop = false;
            jumpInputStartTime = Time.time;
        }

        if (context.canceled)
        {
            JumpInputStop = true;
        }
        Debug.Log("move");
    }

    public void OnInteractInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            InteractInput = true;
        }
        if (context.canceled)
        {
            InteractInput = false;
        }
    }

    public void OnRestartInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            SceneManager.ReloadScene();
        }
    }

    public void OnPauseInput(InputAction.CallbackContext context)
    {
        if (context.started && !PauseManager.isPaused && !PauseInput)
        {
            PauseInput = true;
            CoreManager.current.pause.Pause();
            Debug.Log("pause");
        }
        if (context.started && PauseManager.isPaused && !PauseInput)
        {
            PauseInput = true;
            CoreManager.current.pause.Resume();
            Debug.Log("resume");
        }
        if (context.canceled)
        {
            PauseInput = false;
        }
    }

    public void UseJumpInput() => JumpInput = false;

    private void CheckJumpInputHoldTime()
    {
        if(Time.time >= jumpInputStartTime + inputHoldTime)
        {
            JumpInput = false;
        }
    }
}
