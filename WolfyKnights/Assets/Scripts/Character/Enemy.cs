using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float _moveSpeed;
    private float _knockBackForce = 20;

    private Rigidbody2D _rigid;
    private Rigidbody2D _targetRigid;
    private SpriteRenderer _spriter;
    private Animator _animator;
    private WaitForFixedUpdate _knockBackwait;
    [SerializeField]
    private float _health;
    private float _maxHealth;
    private WaitForSeconds _hitEffectWait = new WaitForSeconds(0.1f);

    private bool _isLive;
    private bool _isHit;
    private Material _originMaterial;
    private Material _hitMaterial;

    private void Awake()
    {
        _rigid = GetComponent<Rigidbody2D>();
        _spriter = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
        _animator.SetFloat("Speed", 1);

        _targetRigid = GameManager.Instance.Player.Rigid;
    }

    private void Start()
    {
        _originMaterial = _spriter.material;
        _hitMaterial = MaterialManager.GetMaterial(0);
    }

    private void OnEnable()
    {
        _isLive = true;
        _health = _maxHealth;
    }
    private void OnDisable()
    {
        _isLive = false;
    }

    public void Init(int id)
    {
        EnemyData data = DataManager.EnemyDict[id];
        _maxHealth = data.Health;
        _health = _maxHealth;
        _moveSpeed = data.MoveSpeed;
        _animator.runtimeAnimatorController = AnimManager.EnemyAnimCons[data.ResourceId];
    }

    private void FixedUpdate()
    {
        if (_isHit)
        {
            _isHit = false;
            return;
        }
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



    private void Dead()
    {
        gameObject.SetActive(false);
        GameManager.Instance.Pool.Enemy.DestroyEnemy(this);
    }

    public void Hit(int damage)
    {
        _health -= damage;
        if (_health > 0)
        {
            Debug.Log("KnockBack");
            StartCoroutine(KnockBack());
        }
        else
        {
            Dead();
        }
    }

    private IEnumerator KnockBack()
    {
        yield return _knockBackwait;
        _isHit = true;
        _spriter.material = _hitMaterial;
        StartCoroutine(ChangeMaterial());
        Vector2 playerPos = _targetRigid.position;
        Vector2 dirVec = _rigid.position - playerPos;
        _rigid.AddForce(dirVec.normalized * _knockBackForce, ForceMode2D.Impulse);
    }

    private IEnumerator ChangeMaterial()
    {
        yield return _hitEffectWait;
        _spriter.material = _originMaterial;
    }
}   