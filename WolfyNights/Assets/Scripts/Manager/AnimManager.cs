using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AnimManager
{
    public static RuntimeAnimatorController[] EnemyAnimCons { get; private set; }
    public static RuntimeAnimatorController[] HeroAnimCons { get; private set; }

    public static void LoadAnimCon()
    {
        EnemyAnimCons = Resources.LoadAll<RuntimeAnimatorController>("Resources/Animations/Enemy");
        HeroAnimCons = Resources.LoadAll<RuntimeAnimatorController>("Resources/Animations/Hero");
    }
}
