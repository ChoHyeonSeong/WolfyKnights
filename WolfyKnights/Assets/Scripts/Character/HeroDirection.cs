using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroDirection : MonoBehaviour
{
    private float _angle;

    private void OnEnable()
    {
        PlayerJoystick.OnInput += UpdateDirection;
    }

    private void OnDisable()
    {
        PlayerJoystick.OnInput -= UpdateDirection;
    }

    private void UpdateDirection(Vector2 input)
    {
        _angle = Mathf.Atan2(input.y, input.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(_angle - 90, Vector3.forward);
    }
}
