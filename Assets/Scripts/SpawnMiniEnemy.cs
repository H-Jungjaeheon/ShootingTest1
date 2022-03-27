using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMiniEnemy : Enemy
{
    [SerializeField] private float ShootCount, MaxShootCount, XSpeed, RandMove;
    [SerializeField] private GameObject Bullet;

    public override void Awake()
    {
        base.Awake();
        RandMove = Random.Range(0, 2);
        if(RandMove == 0)
        {
            XSpeed *= -1;
        }
    }
    // Update is called once per frame
    public override void FixedUpdate()
    {
        base.FixedUpdate();
        Shoot();
    }
    public override void Move()
    {
        transform.position -= new Vector3(XSpeed * Time.deltaTime, 0, Speed * Time.deltaTime);
        if(transform.position.x >= 8 || transform.position.x <= -8)
        {
            XSpeed *= -1;
        }
    }
    void Shoot()
    {
        ShootCount += Time.deltaTime;
        if(ShootCount > MaxShootCount)
        {
            for(int a = -30; a < 31; a += 60)
            Instantiate(Bullet, transform.position, Quaternion.Euler(90, 0, a));
            ShootCount = 0;
        }
    }
    public override void Dead()
    {
        if (Hp <= 0)
        {
            for (int a = -30; a < 31; a += 60)
            {
                Instantiate(Bullet, transform.position, Quaternion.Euler(90, 0, a));
            }
            for (int a = 150; a < 211; a += 60)
            {
                Instantiate(Bullet, transform.position, Quaternion.Euler(90, 0, a));
            }
            Instantiate(DeadEffect).transform.position = transform.position;
            GameManager.Instance.Score += Score;
            Destroy(this.gameObject);
        }   
    }
}
