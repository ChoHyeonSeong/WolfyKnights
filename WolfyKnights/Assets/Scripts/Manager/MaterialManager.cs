using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MaterialManager
{
    private static Material[] _materials;
        
    public static void LoadMaterial()
    {
        _materials = Resources.LoadAll<Material>("Materials/Instancing");
    }

    public static Material GetMaterial(int index)
    {
        return Object.Instantiate(_materials[index]);
    }
}
