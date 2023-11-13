using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public PoolManager Pool;
    public Hero Player;

    public float GameTime;
    public float MaxGameTime = 2 * 10f;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        GameTime += Time.deltaTime;
        if(GameTime>MaxGameTime)
        {
            GameTime = MaxGameTime;
        }
    }
}
