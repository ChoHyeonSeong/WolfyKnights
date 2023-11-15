using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    [SerializeField]
    private Enemy _enemyPrefab;

    private Queue<Enemy> _enemyPool = new Queue<Enemy>();


    public Enemy CreateEnemy(Vector3 position)
    {
        Enemy obj;
        if (_enemyPool.Count > 0)
        {
            obj = _enemyPool.Dequeue();
            obj.transform.position = position;
            obj.gameObject.SetActive(true);
        }
        else
        {
            obj = Instantiate(_enemyPrefab, position, Quaternion.identity, transform);
        }
        return obj;
    }

    public Enemy CreateEnemy()
    {
        return CreateEnemy(Vector3.zero);
    }

    public void DestroyEnemy(Enemy enemy)
    {
        enemy.gameObject.SetActive(false);
        _enemyPool.Enqueue(enemy);
    }
}
