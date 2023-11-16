using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bullet : MonoBehaviour
{
    public int BulletIndex { get => _bulletData.Id / 10; }

    private BulletData _bulletData;

    public void Init(BulletData data)
    {
        _bulletData = data;
    }

    public abstract void Shoot();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Enemy"))
            return;
        collision.GetComponent<Enemy>().Hit(_bulletData.Damage);
    }
}
