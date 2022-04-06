using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBossBullet : EnemyBullet
{
    [SerializeField] private int BulletKind;
    [SerializeField] private GameObject[] OtherBullet;
    [SerializeField] private float BulletSpawnCount, BulletTime, CirclePower;
    [SerializeField] private bool CircleLeft;
    [SerializeField] private Rigidbody rigid;
    [SerializeField] private GameObject Boss2, Warning, BulletParticles;
    public override void Start()
    {
        base.Start();
        Boss2 = GameObject.Find("FinalBoss");
        rigid = GetComponent<Rigidbody>();
        if(BulletKind == 2)
        {
            Speed = 0;
        }
    }
    public override void Update()
    {
        switch (BulletKind)
        {
            case 1:
                BulletMove();
                break;
            case 2:
                BulletBoom();
                break;
            case 3:
                DoubleBulletMove();
                break;
            case 4:
                Invoke("SuperFastBullet", 2f);
                break;
            case 5:
                GoDownBullet();
                break;
        }
    }
    void BulletBoom()
    {
        float MaxTime = 4;
        float Z = Speed * (Time.deltaTime * 2.8f);
        float RY = transform.position.y * 5;
        Speed += Time.deltaTime;
        BulletSpawnCount += Time.deltaTime;
        BulletTime += Time.deltaTime;
        transform.Translate(0, 0, -Z);
        if (BulletSpawnCount > 1)
        {
            for (int a = -90; a <= 90; a+= 180)
            {
                Instantiate(OtherBullet[0], transform.position, Quaternion.Euler(0, 0, a));
            }
            BulletSpawnCount = 0;
        }
        if(MaxTime <= BulletTime)
        {
            for (int a = 0; a <= 360; a += 40)
            {
                Instantiate(OtherBullet[0], transform.position, Quaternion.Euler(90,0,a));
                Destroy(this.gameObject);
            }
        }
    }
    void DoubleBulletMove()
    {
        float Z = CirclePower * Time.deltaTime;
        //transform.position = new Vector3(XP + Mathf.Cos(Time.time * Speed) * CirclePower, transform.position.y, ZP + Mathf.Sin(Time.time * Speed) * CirclePower);
        transform.Translate(Z, 0, 0);
        if(CircleLeft == true)
        {
            transform.RotateAround(Boss2.transform.position, new Vector3(0, -1, 0), Speed);
        }
        else
        {
            transform.RotateAround(Boss2.transform.position, Vector3.down, -Speed);
        }
    }
    void SuperFastBullet()
    {
        BulletTime += Time.deltaTime;
        Warning.SetActive(false);
        transform.Translate(0, -Speed * Time.deltaTime, 0);
        if(BulletTime >= BulletSpawnCount)
        {
            Instantiate(OtherBullet[0], transform.position, Quaternion.Euler(0, 0, 0));
            BulletTime = 0;
            BulletSpawnCount = Random.Range(0.05f, 0.15f);
        }
    }
    void GoDownBullet()
    {
        transform.Translate(0, Speed * Time.deltaTime, 0);
        Speed += 0.1f;
    }
    public override void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (GameManager.Instance.IsHit == false && GameManager.Instance.IsShild == false)
            {
                GameManager.Instance.Hp -= Damage;
            }
            Destroy(this.gameObject);
        }
        if (other.gameObject.CompareTag("ObjDestroy") || other.gameObject.CompareTag("RedCell"))
        {
            if(BulletKind == 2)
            {
                for (int a = 0; a <= 360; a += 40)
                {
                    Instantiate(OtherBullet[0], transform.position, Quaternion.Euler(90, 0, a));
                }
                Instantiate(BulletParticles).transform.position = transform.position;
                Destroy(this.gameObject);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }
    }
    //public override void BulletMove()
    //{
    //    float Z = Speed * Time.deltaTime;
    //    this.transform.Translate(0, -Z, 0);
    //}
}
