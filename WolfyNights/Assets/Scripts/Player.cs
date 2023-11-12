using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Vector2 InputVec { get; private set; }

    [SerializeField]
    private VariableJoystick _joystick;

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
        InputVec = new Vector2(_joystick.Horizontal, _joystick.Vertical);
    }

    private void FixedUpdate()
    {
        Vector2 nextVec = InputVec.normalized * _moveSpeed * Time.fixedDeltaTime;
        _rigidbody.MovePosition(_rigidbody.position + nextVec);
    }

    private void LateUpdate()
    {
        _animator.SetFloat("Speed", InputVec.sqrMagnitude > 0 ? 1 : 0);
        if (InputVec.x !=0)
        {
            _spriter.flipX = InputVec.x < 0;
        }
    }
}
