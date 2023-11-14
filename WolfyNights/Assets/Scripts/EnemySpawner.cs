using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    private int _enemyCount;
    private int _enemyLevel;
    private List<int> _levelUpCount;

    public SpawnData[] SpawnDatas;

    // Start is called before the first frame update
    private void Start()
    {
        SpawnStart(0);
    }

    private void SpawnStart(int id)
    {
        SpawnData data = SpawnDatas[id];
        _enemyLevel = 0;
        _enemyCount = 0;
        _levelUpCount = new List<int>() { data.EnemyCounts[0] };
        for (int i = 1; i < data.EnemyIds.Length; i++)
        {
            _levelUpCount.Add(data.EnemyCounts[i] + _levelUpCount[i - 1]);
        }
        StartCoroutine(SpawnEnemy(data));
    }

    private IEnumerator SpawnEnemy(SpawnData data)
    {
        yield return new WaitForSeconds((_levelUpCount[_enemyLevel] - _enemyCount) / (float)_levelUpCount[_enemyLevel]);

        Vector3 spawnPos = (Random.insideUnitCircle.normalized * 6);
        spawnPos += GameManager.Instance.Player.transform.position;
        GameManager.Instance.Pool.Enemy.CreateEnemy(spawnPos).Init(data.EnemyIds[_enemyLevel]);
        _enemyCount++;
        if (_enemyCount == _levelUpCount[_enemyLevel])
        {
            _enemyLevel++;
        }
        if (_enemyLevel < _levelUpCount.Count)
        {
            StartCoroutine(SpawnEnemy(data));
        }
    }
}

[Serializable]
public class SpawnData
{
    public int[] EnemyIds;
    public int[] EnemyCounts;
}