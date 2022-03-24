using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBossBullet : EnemyBullet
{
    [SerializeField] private int BulletKind;
    public override void Update()
    {
        switch (BulletKind)
        {
            case 1:
                BulletMove();
                break;
            case 2:
                BulletDoubleMove();
                break;
            case 3:

                break;
        }
    }
    void BulletDoubleMove()
    {
        float Z = Speed * Time.deltaTime;
        this.transform.position += new Vector3(-Z, 0, -Z);
    }
    //public override void BulletMove()
    //{
    //    float Z = Speed * Time.deltaTime;
    //    this.transform.Translate(0, -Z, 0);
    //}
}
