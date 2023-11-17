using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slash : Skill
{
    public override void DoSkill()
    {
        Vector2 skillPos = _hero.transform.position;
        skillPos += Vector2.right * (_hero.IsLeft ? -1f : 1f);
        Quaternion skillRot = Quaternion.Euler(new Vector3(0, 0, _hero.IsLeft ? 180 : 0));
        Bullet bullet = GameManager.Instance.Pool.Bullet.CreateBullet(_skillIndex, _skillLevel, skillPos, skillRot);
        bullet.Shoot();
    }

    public override void StartSkill(Hero hero)
    {
        base.StartSkill(hero);
    }
}
