using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private VariableJoystick _joystick;
    private Vector2 _inputVec;

    private Rigidbody2D _rigidbody;
    private SpriteRenderer _spriter;
    private Animator _animator;
    private float _moveSpeed = 1;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _spriter = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
    }
    private void Update()
    {
        _inputVec = new Vector2(_joystick.Horizontal, _joystick.Vertical);
    }

    private void FixedUpdate()
    {
        Vector2 nextVec = _inputVec.normalized * _moveSpeed * Time.fixedDeltaTime;
        _rigidbody.MovePosition(_rigidbody.position + nextVec);
    }

    private void LateUpdate()
    {
        _animator.SetFloat("Speed", _inputVec.sqrMagnitude);
        if(_inputVec.x !=0)
        {
            _spriter.flipX = _inputVec.x < 0;
        }
    }
}
