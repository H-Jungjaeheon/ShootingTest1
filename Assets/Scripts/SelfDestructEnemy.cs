using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestructEnemy : Enemy
{
    [SerializeField] private GameObject Bullet;

    public override void Awake()
    {
        base.Awake();
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
        }
    }
    public override void Dead()
    {
        if (Hp <= 0)
        {
            for (int a = -50; a < 251; a += 50)
            {
                Instantiate(Bullet, transform.position, Quaternion.Euler(90, 0, a));
            }
            Instantiate(DeadEffect).transform.position = transform.position;
            Destroy(this.gameObject);
            GameManager.Instance.Score += Score;
        }
    }
}
