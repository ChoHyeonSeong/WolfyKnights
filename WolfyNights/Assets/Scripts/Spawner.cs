using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    private int _level;
    private float _timer;

    public SpawnData[] SpawnDatas;

    private void Update()
    {
        _level = Mathf.FloorToInt(GameManager.Instance.GameTime / 10f);
    }

    // Start is called before the first frame update
    private void Start()
    {
        InvokeRepeating("Spawn", 0, 1);
    }

    private void Spawn()
    {
        Vector3 spawnPos = (Random.insideUnitCircle.normalized * 6);
        spawnPos += GameManager.Instance.Player.transform.position;
        GameManager.Instance.Pool.Create(0, spawnPos).GetComponent<Enemy>().Init(SpawnDatas[_level]);
    }
}

[Serializable]
public class SpawnData
{
    public int SpriteType;
    public float SpawnTime;
    public int Health;
    public float Speed;
}