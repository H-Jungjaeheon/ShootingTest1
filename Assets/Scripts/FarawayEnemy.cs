using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarawayEnemy : Enemy
{
    [SerializeField] private float ShootCount, MaxShootCount;
    [SerializeField] private GameObject Bullet;
 
    public override void FixedUpdate()
    {
        base.FixedUpdate();
        ShootCount += Time.deltaTime;
        if(ShootCount >= MaxShootCount)
        {
            Shoot();
        }
    }
    public override void Move()
    {            
        transform.position -= new Vector3(0, 0, Speed * Time.deltaTime);       
    }
    public void Shoot()
    {
        Instantiate(Bullet, this.transform.position, Quaternion.Euler(90, 0, 0));
        ShootCount = 0;
    }
}
