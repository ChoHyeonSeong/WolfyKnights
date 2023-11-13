using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float _moveSpeed;

    private Rigidbody2D _rigid;
    private Rigidbody2D _targetRigid;
    private SpriteRenderer _spriter;
    private Animator _animator;
    [SerializeField]
    private RuntimeAnimatorController[] _animCon;
    private float health;
    private float maxHealth;

    private bool _isLive;

    private void Awake()
    {
        _rigid = GetComponent<Rigidbody2D>();
        _spriter = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
        _animator.SetFloat("Speed", 1);

        _targetRigid = GameManager.Instance.Player.Rigid;
    }
    private void OnEnable()
    {
        _isLive = true;
        health = maxHealth;
    }
    private void OnDisable()
    {
        _isLive = false;
    }

    public void Init(SpawnData data)
    {
        maxHealth = data.Health;
        _moveSpeed = data.Speed;
        _animator.runtimeAnimatorController = _animCon[data.SpriteType];
    }

    private void FixedUpdate()
    {
        if (!_isLive)
            return;

        Vector2 dirVec = _targetRigid.position - _rigid.position;
        Vector2 nextVec = dirVec.normalized * _moveSpeed * Time.fixedDeltaTime;
        _rigid.MovePosition(_rigid.position + nextVec);
        _rigid.velocity = Vector2.zero;
    }

    private void LateUpdate()
    {
        if (!_isLive)
            return;

        _spriter.flipX = _targetRigid.position.x < _rigid.position.x;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Bullet"))
            return;
        health -= collision.GetComponent<Sword>().damage;
        if(health > 0)
        {

        }
        else
        {
            Dead();
        }
    }

    private void Dead()
    {
        gameObject.SetActive(false);
        GameManager.Instance.Pool.DestroyEnemy(gameObject, 0);
    }
}
