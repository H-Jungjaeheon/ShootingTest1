using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : Enemy
{
    [SerializeField] private float SpawnCount, MaxSpawnCount;

    // Update is called once per frame
    public override void FixedUpdate()
    {
        base.FixedUpdate();
    }
    public override void Move()
    {
        transform.position -= new Vector3(0, 0, Speed * Time.deltaTime);
    }
    public override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
    }
}
