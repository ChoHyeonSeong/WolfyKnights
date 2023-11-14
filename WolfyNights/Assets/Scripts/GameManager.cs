using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public PoolManager Pool { get; private set; }
    public Hero Player;

    public float MaxGameTime = 2 * 10f;

    private void Awake()
    {
        Instance = this;
        Pool = FindAnyObjectByType<PoolManager>();
        AnimManager.LoadAnimCon();
        DataManager.LoadData();
        Pool.LoadPool();
    }
}
