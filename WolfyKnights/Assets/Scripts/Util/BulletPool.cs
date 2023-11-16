using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    private Bullet[] _bullets;
    private Queue<Bullet>[] _bulletPools;

    private void Awake()
    {
        _bullets = Resources.LoadAll<Bullet>("Prefabs/Bullet");
        _bulletPools = new Queue<Bullet>[_bullets.Length];

        for (int i = 0; i < _bullets.Length; i++)
        {
            _bulletPools[i] = new Queue<Bullet>();
        }
    }

    public Bullet CreateBullet(int index, int level, Vector2 pos, Quaternion rot)
    {
        Bullet bullet;
        if (_bulletPools[index].Count > 0)
        {
            bullet = _bulletPools[index].Dequeue();
            bullet.transform.SetPositionAndRotation(pos, rot);
            bullet.Init(DataManager.BulletDict[index * 10 + level]);
            bullet.gameObject.SetActive(true);
        }
        else
        {
            bullet = Instantiate(_bullets[index], pos, rot, transform);
            bullet.Init(DataManager.BulletDict[index * 10 + level]);
            bullet.gameObject.SetActive(true);
        }
        return bullet;
    }

    public void DestroyBullet(Bullet bullet)
    {
        bullet.gameObject.SetActive(false);
        _bulletPools[bullet.BulletIndex].Enqueue(bullet);
    }
}
