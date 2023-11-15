using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DataManager
{
    public static Dictionary<int, HeroData> HeroDict { get; private set; } = new Dictionary<int, HeroData>();
    public static Dictionary<int, EnemyData> EnemyDict { get; private set; } = new Dictionary<int, EnemyData>();
    public static Dictionary<int, StageData> StageDict { get; private set; } = new Dictionary<int, StageData>();

    public static void LoadData()
    {
        var heroTable = Resources.Load("Datas/ScrObj/HeroTable") as HeroTable;
        foreach (var hero in heroTable.Heroes)
        {
            HeroDict[hero.Id] = hero;
        }

        var enemyTable = Resources.Load("Datas/ScrObj/EnemyTable") as EnemyTable;
        foreach (var enemy in enemyTable.Enemies)
        {
            EnemyDict[enemy.Id] = enemy;
        }

        var stageTable = Resources.Load("Datas/ScrObj/StageTable") as StageTable;
        foreach (var stage in stageTable.Stages)
        {
            StageDict[stage.Id] = stage;
        }
    }
}
