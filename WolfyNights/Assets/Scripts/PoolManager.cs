using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public GameObject[] _prefabs;

    private Queue<GameObject>[] _pools;

    public GameObject Create(int index, Vector3 position)
    {
        GameObject obj;
        if (_pools[index].Count > 0)
        {
            obj = _pools[index].Dequeue();
            obj.transform.position = position;
            obj.SetActive(true);
        }
        else
        {
            obj = Instantiate(_prefabs[index], position, Quaternion.identity, transform);
        }
        return obj;
    }

    public GameObject Create(int index)
    {
        return Create(index, Vector3.zero);
    }

    public void Destroy(GameObject enemy, int index)
    {
        enemy.SetActive(false);
        _pools[index].Enqueue(enemy);
    }


    private void Awake()
    {
        _pools = new Queue<GameObject>[_prefabs.Length];

        for (int i = 0; i < _pools.Length; i++)
        {
            _pools[i] = new Queue<GameObject>();
        }
    }
}
