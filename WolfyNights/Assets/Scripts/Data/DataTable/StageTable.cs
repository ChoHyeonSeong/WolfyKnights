using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Stage Data", menuName = "Scriptable Object/Stage Data", order = int.MaxValue)]
public class StageTable : ScriptableObject
{
    public List<StageData> Stages; // Replace 'EntityType' to an actual type that is serializable.
}
