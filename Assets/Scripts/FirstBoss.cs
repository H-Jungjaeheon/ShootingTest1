using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstBoss : Enemy
{
    [Header("패턴 관련 변수")]
    [SerializeField] private float a;
    [SerializeField] private bool IsPattonUse;
    [SerializeField] private GameObject[] BossBullet, Enemys;
    [SerializeField] private GameObject players;
    public override void Awake()
    {
        IsGo = true;
        IsMove = false;
        rigid = GetComponent<Rigidbody>();
        mesh = GetComponent<MeshRenderer>();
        Hp *= GameManager.Instance.Stage + GameManager.Instance.Damage;
        MaxHp *= GameManager.Instance.Stage + GameManager.Instance.Damage;
    }
    // Update is called once per frame
    public override void FixedUpdate()
    {
        players = GameObject.FindGameObjectWithTag("Player");
        a = players.transform.position.x * 3;
        if (IsMove == true)
        {
            Move();
        }
        else
        {
            StartMove();
        }
        if(IsPattonUse == false && IsMove == true)
        {
            Attack();
        }
        Dead();
        mesh.material = material[0];
    }
    void Attack() //공격 끝난 후 쉬는 타임 존재
    {
        int a = Random.Range(0, 4);
        switch (a)
        {
            case 0:
                IsPattonUse = true;
                StartCoroutine(Patton1());
                break;
            case 1:
                IsPattonUse = true;
                Instantiate(BossBullet[0], transform.position, Quaternion.Euler(0, 0, 0));
                StartCoroutine(Patton2());
                break;
            case 2:
                IsPattonUse = true;
                Instantiate(BossBullet[0], transform.position, Quaternion.Euler(0, 0, 0));
                StartCoroutine(Patton3());
                break;
            case 3:
                IsPattonUse = true;
                Instantiate(BossBullet[0], transform.position, Quaternion.Euler(0, 0, 0));
                StartCoroutine(Patton4());
                break;
        }
    }
    IEnumerator Patton1()
    {
        for (int z = 0; z < 31; z += 2)
        { 
            for (int i = -40; i < 41; i += 80) 
            {
                if(i > 0)
                {
                    Instantiate(BossBullet[0], transform.position, Quaternion.Euler(90, 0, i - z));
                }
                else
                {
                    Instantiate(BossBullet[0], transform.position, Quaternion.Euler(90, 0, i + z));
                }
            }
            yield return new WaitForSeconds(0.2f);
            if(z % 7 == 0)
            {
                for (int i = -10; i < 11; i += 10)
                {
                    Instantiate(BossBullet[1], transform.position, Quaternion.Euler(90, 0, a + i));
                }
            }
        }
        for (int z = 30; z > 0; z -= 2)
        {
            for (int i = -40; i < 41; i += 80)
            {
                if (i > 0)
                {
                    Instantiate(BossBullet[0], transform.position, Quaternion.Euler(90, 0, i - z));
                }
                else
                {
                    Instantiate(BossBullet[0], transform.position, Quaternion.Euler(90, 0, i + z));
                }
            }
            yield return new WaitForSeconds(0.2f);
            if (z % 7 == 0)
            {
                for (int i = -10; i < 11; i += 10)
                {
                    Instantiate(BossBullet[1], transform.position, Quaternion.Euler(90, 0, a + i));
                }
            }
        }
        for (int z = 0; z < 31; z += 2)
        {
            for (int i = -40; i < 41; i += 80)
            {
                if (i > 0)
                {
                    Instantiate(BossBullet[0], transform.position, Quaternion.Euler(90, 0, i - z));
                }
                else
                {
                    Instantiate(BossBullet[0], transform.position, Quaternion.Euler(90, 0, i + z));
                }
            }
            yield return new WaitForSeconds(0.2f);
            if (z % 7 == 0)
            {
                for (int i = -10; i < 11; i += 10)
                {
                    Instantiate(BossBullet[1], transform.position, Quaternion.Euler(90, 0, a + i));
                }
            }
        }
        yield return new WaitForSeconds(3);
        IsPattonUse = false;
        yield return null;
    }
    IEnumerator Patton2()
    {
        Instantiate(Enemys[0], transform.position, Quaternion.Euler(0, 0, 0));
        yield return new WaitForSeconds(0.8f);
        for (int a = -2; a < 3; a += 4)
        {
            Instantiate(Enemys[0], transform.position + new Vector3(a,0,0), Quaternion.Euler(0, 0, 0));
        }
        yield return new WaitForSeconds(2f);
        for (int a = -3; a < 4; a += 6)
        {
            Instantiate(Enemys[1], transform.position + new Vector3(a, 0, 0), Quaternion.Euler(0, 0, 0));
        }
        yield return new WaitForSeconds(2f);
        Instantiate(Enemys[2], transform.position, Quaternion.Euler(0, 0, 0));
        yield return new WaitForSeconds(5);
        IsPattonUse = false;
        yield return null;
    }
    IEnumerator Patton3()
    {
        float a = 0;
        float d = 0;
        for(int b = 0; b < 1501; b += 15)
        {
            for (int c = 0; c < 271; c += 90)
            {
                Instantiate(BossBullet[0], transform.position, Quaternion.Euler(90, 0, a + b + c));
                a+=0.5f;
            }
            yield return new WaitForSeconds(0.07f);
            d -= 47;
            transform.rotation = Quaternion.Euler(0, d, 0);
        }
        transform.rotation = Quaternion.Euler(0, 0, 0);
        yield return new WaitForSeconds(3);
        IsPattonUse = false;
        yield return null;
    }
    IEnumerator Patton4()
    {
        for (int z = 0; z < 16; z += 1)
        {
            for (int i = -30; i < 31; i += 15)
            {
                Instantiate(BossBullet[0], transform.position, Quaternion.Euler(90, 0, i));
            }
            yield return new WaitForSeconds(0.1f);
        }
        for (int z = 0; z < 16; z += 1)
        {
            for (int i = -30; i < 31; i += 15)
            {
                Instantiate(BossBullet[0], transform.position, Quaternion.Euler(90, 0, i + z));
            }
            yield return new WaitForSeconds(0.1f);
        }
        for (int z = 15; z > -16; z -= 1)
        {
            for (int i = -30; i < 31; i += 15)
            {
                Instantiate(BossBullet[0], transform.position, Quaternion.Euler(90, 0, i + z));
            }
            yield return new WaitForSeconds(0.1f);
        }
        yield return new WaitForSeconds(3);
        IsPattonUse = false;
        yield return null;
    }
    void StartMove()
    {
        if(transform.position.z >= 15)
        {
            transform.position = Vector3.MoveTowards(transform.position, transform.position - new Vector3(0, 0, 15), 2 * Time.deltaTime);
        }
        else
        {
            IsMove = true;
        }
    }
    public override void Move()
    {
        //transform.position -= new Vector3(Speed * Time.deltaTime, 0, 0);       
    }

    public override void Dead()
    {
        if (Hp <= 0)
        {
            Instantiate(DeadEffect).transform.position = transform.position;
            Destroy(this.gameObject);
            GameManager.Instance.Score += Score;
        }
    }
    public override void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet") && GameManager.Instance.Hp > 0 && IsMove == true)
        {
            Hp -= GameManager.Instance.Damage;
            StartCoroutine(EnemyHit());
        }
        else if (other.gameObject.CompareTag("Player"))
        {
            if (GameManager.Instance.IsHit == false && GameManager.Instance.IsShild == false)
            {
                GameManager.Instance.Hp -= Damage;
            }
            Hp -= GameManager.Instance.Damage / 2;
        }
    }

    public override IEnumerator EnemyHit()
    {
        mesh.material = material[1];
        yield return new WaitForSeconds(0.5f);
        mesh.material = material[0];
        yield return null;
    }
}
