using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestructEnemy : Enemy
{
    [SerializeField] private float SelfDestructCount, MaxSelfDestructCount;
    [SerializeField] private GameObject Bullet;

    public override void Awake()
    {
        base.Awake();
        MaxSelfDestructCount = Random.Range(4, 6);
        IsMove = true;
    }
    public override void Move()
    {
        if (IsMove == true)
        {
            transform.position -= new Vector3(0, 0, Speed * Time.deltaTime);
        }
        if(transform.position.z <= 0)
        {
            IsMove = false;
            SelfDestruct();
        }
    }
    void SelfDestruct()
    {
        SelfDestructCount += Time.deltaTime;
        if(SelfDestructCount >= MaxSelfDestructCount)
        {
            for (int a = -50; a < 251; a += 50)
            {
                Instantiate(Bullet, transform.position, Quaternion.Euler(90, 0, a));
            }
            Destroy(this.gameObject);
        }
    }
}
