using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float _moveSpeed = 0.5f;
    public Rigidbody2D _targetRigid;

    private Rigidbody2D _rigid;
    private SpriteRenderer _spriter;
    private Animator _animator;

    private bool _isLive = true;

    private void Awake()
    {
        _rigid = GetComponent<Rigidbody2D>();
        _spriter = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
        _animator.SetFloat("Speed", 1);
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
}
