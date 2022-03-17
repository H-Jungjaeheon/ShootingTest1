using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplitEnemy : Enemy
{
    [SerializeField] GameObject MiniObj;
    [SerializeField] bool IsSpawnMini;
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    public override void FixedUpdate()
    {
        base.FixedUpdate();
    }
    public override void Move()
    {
        base.Move();
    }
    public override IEnumerator ChangeX()
    {
        return base.ChangeX();
    }
    public override void Turn()
    {
        base.Turn();
    }
    public override void Dead()
    {
        if (Hp <= 0)
        {
            if (IsSpawnMini == true)
            {
                for (float a = -0.9f; a < 1f; a += 1.8f)
                {
                    Instantiate(MiniObj, transform.position + new Vector3(a, 0, 0), Quaternion.Euler(0, 0, 0));
                }
            }
            Destroy(this.gameObject);
            //점수 증가
        }
    }
    public override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
    }
    public override IEnumerator EnemyHit()
    {
        return base.EnemyHit();
    }
}
