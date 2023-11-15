using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJoystick : MonoBehaviour
{
    public static Action<Vector2> OnInputJoystick { get; set; }

    private VariableJoystick _joystick;
    private Vector2 _inputVec;

    private void Awake()
    {
        _joystick = GetComponentInChildren<VariableJoystick>();

        _inputVec = new Vector2();
    }

    // Update is called once per frame
    void Update()
    {
        _inputVec.x = _joystick.Horizontal;
        _inputVec.y = _joystick.Vertical;
        OnInputJoystick(_inputVec);
    }
}
