using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private Material _hitMaterial;
    private int _enemyCount;
    private int _enemyLevel;
    private List<int> _levelUpCount;

    public void SpawnStart(int id)
    {
        StageData data = DataManager.StageDict[id];
        _enemyLevel = 0;
        _enemyCount = 0;
        _levelUpCount = new List<int>() { data.EnemyCounts[0] };
        for (int i = 1; i < data.EnemyIds.Length; i++)
        {
            _levelUpCount.Add(data.EnemyCounts[i] + _levelUpCount[i - 1]);
        }
        StartCoroutine(SpawnEnemy(data));
    }

    private IEnumerator SpawnEnemy(StageData data)
    {
        yield return new WaitForSeconds((_levelUpCount[_enemyLevel] - _enemyCount) / (float)_levelUpCount[_enemyLevel]);

        Vector3 spawnPos = (Random.insideUnitCircle.normalized * 12);
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