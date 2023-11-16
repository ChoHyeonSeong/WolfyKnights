using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    protected Hero _hero;

    [SerializeField]
    protected int _skillIndex;

    protected int _skillLevel = 1;

    public virtual void StartSkill(Hero hero) { _hero = hero; }

    public virtual void DoSkill() { }
}
