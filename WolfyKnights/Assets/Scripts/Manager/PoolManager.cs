using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public EnemyPool Enemy { get; private set; }
    public BulletPool Bullet { get; private set; }

    public void LoadPool()
    {
        Enemy = GetComponent<EnemyPool>();
        Bullet = GetComponent<BulletPool>();
    }
}
