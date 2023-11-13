using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    private GameObject[] _enemyPrefabs;

    private Queue<GameObject>[] _enemyPools;

    private Queue<GameObject>[] _itemPools; 

    public GameObject CreateEnemy(int index, Vector3 position)
    {
        GameObject obj;
        if (_enemyPools[index].Count > 0)
        {
            obj = _enemyPools[index].Dequeue();
            obj.transform.position = position;
            obj.SetActive(true);
        }
        else
        {
            obj = Instantiate(_enemyPrefabs[index], position, Quaternion.identity, transform);
        }
        return obj;
    }

    public GameObject CreateEnemy(int index)
    {
        return CreateEnemy(index, Vector3.zero);
    }

    public void DestroyEnemy(GameObject enemy, int index)
    {
        enemy.SetActive(false);
        _enemyPools[index].Enqueue(enemy);
    }


    private void Awake()
    {
        _enemyPrefabs = Resources.LoadAll<GameObject>("Prefabs/Enemy");
        _enemyPools = new Queue<GameObject>[_enemyPrefabs.Length];

        for (int i = 0; i < _enemyPools.Length; i++)
        {
            _enemyPools[i] = new Queue<GameObject>();
        }
    }
}
