using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    public Vector2 InputVec { get; private set; }
    public Rigidbody2D Rigid { get; private set; }

    private SpriteRenderer _spriter;
    private Animator _animator;
    private Vector2 _nextVec;

    private int _maxHealth;
    private int _health;
    private float _moveSpeed;

    public void Init(HeroData data)
    {
        _maxHealth = data.Health;
        _health = _maxHealth;
        _moveSpeed = data.MoveSpeed;
    }

    private void Awake()
    {
        Rigid = GetComponent<Rigidbody2D>();
        _spriter = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
        _nextVec = new Vector2();
    }

    private void OnEnable()
    {
        PlayerJoystick.OnInputJoystick += UpdateInputVec;
    }

    private void OnDisable()
    {
        PlayerJoystick.OnInputJoystick -= UpdateInputVec;
    }

    private void UpdateInputVec(Vector2 inputVec)
    {
        InputVec = inputVec;
    }

    private void FixedUpdate()
    {
        _nextVec = InputVec.normalized * _moveSpeed * Time.fixedDeltaTime;
        Rigid.MovePosition(Rigid.position + _nextVec);
    }

    private void LateUpdate()
    {
        _animator.SetFloat("Speed", InputVec.sqrMagnitude > 0 ? 1 : 0);
        if (InputVec.x != 0)
        {
            _spriter.flipX = InputVec.x < 0;
        }
    }
}
