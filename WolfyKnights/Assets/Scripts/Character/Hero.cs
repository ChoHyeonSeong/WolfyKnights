using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Hero : MonoBehaviour
{
    public Rigidbody2D Rigid { get; private set; }

    public bool IsLeft { get; private set; }

    [SerializeField]
    private Transform _skillsTr;

    private SpriteRenderer _spriter;
    private Animator _animator;
    private Vector2 _nextVec;
    private Skill[] _skills;

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
        _skills = GetComponentsInChildren<Skill>();
    }

    private void Start()
    {
        foreach (var skill in _skills)
        {
            skill.StartSkill(this);
        }
        StartCoroutine(Attack());
    }


    private void OnEnable()
    {
        PlayerJoystick.OnInput += UpdateInputVec;
        PlayerJoystick.OnBeginInput += BeginMove;
        PlayerJoystick.OnEndInput += EndMove;
    }

    private void OnDisable()
    {
        PlayerJoystick.OnInput -= UpdateInputVec;
        PlayerJoystick.OnBeginInput -= BeginMove;
        PlayerJoystick.OnEndInput -= EndMove;
    }

    private void UpdateInputVec(Vector2 inputVec)
    {
        IsLeft = inputVec.x < 0;
        _spriter.flipX = IsLeft;
        _nextVec = inputVec.normalized * _moveSpeed * Time.fixedDeltaTime;
        Rigid.MovePosition(Rigid.position + _nextVec);
    }

    private void BeginMove()
    {
        _animator.SetFloat("Speed", 1);
    }

    private void EndMove()
    {
        _animator.SetFloat("Speed", 0);
    }

    private IEnumerator Attack()
    {
        yield return new WaitForSeconds(1);
        foreach (var skill in _skills)
        {
            skill.DoSkill();
        }
        StartCoroutine(Attack());
    }
}
