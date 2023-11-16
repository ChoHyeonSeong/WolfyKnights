using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJoystick : MonoBehaviour
{
    public static Action<Vector2> OnInput { get; set; }
    public static Action OnBeginInput { get; set; }
    public static Action OnEndInput { get; set; }

    private VariableJoystick _joystick;
    private bool _isControl;

    private void Awake()
    {
        _joystick = GetComponentInChildren<VariableJoystick>();
        _isControl = false;
    }
    private void OnEnable()
    {
        _joystick.OnBeginJoystickControl += BeginInput;
        _joystick.OnEndJoystickControl += EndInput;
    }

    private void OnDisable()
    {
        _joystick.OnBeginJoystickControl -= BeginInput;
        _joystick.OnEndJoystickControl -= EndInput;
    }

    private void FixedUpdate()
    {
        if (_isControl)
        {
            OnInput(_joystick.Direction);
        }
    }

    private void BeginInput()
    {
        ToggleIsControl();
        OnBeginInput();
    }

    private void EndInput()
    {
        ToggleIsControl();
        OnEndInput();
    }

    private void ToggleIsControl()
    {
        _isControl = !_isControl;
    }
}
