using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashBullet : Bullet
{
    private ParticleSystem _particle;

    private void Awake()
    {
        _particle = GetComponent<ParticleSystem>();
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

    public override void Shoot()
    {
        _particle.Play();
    }
}
