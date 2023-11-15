using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExcelAsset]
public class HeroTable : ScriptableObject
{
	public List<HeroData> Heroes; // Replace 'EntityType' to an actual type that is serializable.
}
