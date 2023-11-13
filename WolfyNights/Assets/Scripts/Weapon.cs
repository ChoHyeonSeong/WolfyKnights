using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public int Id;
    public int PrefabId;
    public float Damage;
    public int Count;
    public float Speed;

    private void Start()
    {
        Init();
    }

    private void Update()
    {
        switch(Id)
        {
            case 0:
                transform.Rotate(Vector3.back * Speed * Time.deltaTime);
                break;
        }
    }

    public void Init()
    {
        switch(Id)
        {
            case 0:
                Speed = 150;
                Batch();
                break;
            default: 
                break;
        }
    }

    private void Batch()
    {
        for(int i = 0;i < Count; i++)
        {
            Transform bullet = GameManager.Instance.Pool.CreateEnemy(1).transform;
            bullet.parent = transform;

            Vector3 rotVec = Vector3.forward * 360 * i / Count;
            bullet.Rotate(rotVec);
            bullet.Translate(bullet.up * 1.5f, Space.World);
            bullet.GetComponent<Sword>().Init(Damage, -1);
        }
    }
}
