using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : Enemy
{
    [SerializeField] private float SpawnCount, MaxSpawnCount;
    [SerializeField] private GameObject Spawnenemy, Bullet;

    // Update is called once per frame
    public override void FixedUpdate()
    {
        base.FixedUpdate();
        Spawn();
    }
    public override void Move()
    {
        transform.position -= new Vector3(0, 0, Speed * Time.deltaTime);
    }
    public override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
    }
    public override void Dead()
    {
        if (Hp <= 0)
        {
            for(int a = 0; a < 370; a += 20)
            {
                Instantiate(Bullet, transform.position, Quaternion.Euler(90, 0, a));
            }
            Destroy(this.gameObject);
        }
    }
    void Spawn()
    {
        SpawnCount += Time.deltaTime;
        if(SpawnCount > MaxSpawnCount)
        {
            Instantiate(Spawnenemy, transform.position + new Vector3(0, 0, -2), Quaternion.Euler(0, 0, 0));
            SpawnCount = 0;
        }
    }
}
