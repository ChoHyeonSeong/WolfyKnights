using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExcelAsset]
public class BulletTable : ScriptableObject
{
	public List<BulletData> Bullets; // Replace 'EntityType' to an actual type that is serializable.
}
