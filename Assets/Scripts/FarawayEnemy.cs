using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarawayEnemy : Enemy
{
    [SerializeField] float ShootCount, MaxShootCount;
    [SerializeField] GameObject Bullet;
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
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
