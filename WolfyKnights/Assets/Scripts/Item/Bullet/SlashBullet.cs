using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashBullet : Bullet
{
    private float _startTriggerTime = 0.15f;
    private float _keepTriggerTime = 0.1f;

    private ParticleSystem _particle;
    private Collider2D _collider;

    private void Awake()
    {
        _particle = GetComponent<ParticleSystem>();
        _collider = GetComponent<Collider2D>();
    }

    private void OnEnable()
    {
    }

    private void OnDisable()
    {
        
    }

    private void Update()
    {
        if (!_particle.IsAlive())
        {
            GameManager.Instance.Pool.Bullet.DestroyBullet(this);
        }
    }

    private void EnableCollider()
    {
        _collider.enabled = true;
        Invoke("DisableCollider", _keepTriggerTime);
    }

    private void DisableCollider()
    {
        _collider.enabled = false;
    }

    public override void Shoot()
    {
        _particle.Play();
        Invoke("EnableCollider", _startTriggerTime);
    }
}
