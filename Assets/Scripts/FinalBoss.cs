using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBoss : Enemy
{
    [Header("패턴 관련 변수")]
    [SerializeField] private float A, B, C, MoveShoot;
    [SerializeField] private bool IsPattonUse, IsPattonMove, IsDead;
    [SerializeField] private GameObject[] BossBullet, Enemys;
    [SerializeField] private GameObject players, Warning;

    public override void Awake()
    {
        IsGo = true;
        rigid = GetComponent<Rigidbody>();
        mesh = GetComponent<MeshRenderer>();
        Hp *= GameManager.Instance.Stage + GameManager.Instance.Damage;
        MaxHp *= GameManager.Instance.Stage + GameManager.Instance.Damage;
        B = 0; //3패턴 값
    }
    // Update is called once per frame
    public override void FixedUpdate()
    {
        players = GameObject.FindGameObjectWithTag("Player");
        if(IsMove == false && IsDead == false)
        {
            StartMove();
        }
        if(IsPattonMove == true && IsDead == false)
        {
            Move();
        }
        if(IsPattonUse == false && IsMove == true && IsDead == false)
        {
            Attack();
        }
        Dead();
    }
    void Attack() 
    {
        int a = Random.Range(0, 6);
        switch (a)
        {
            case 0:
                IsPattonUse = true;
                StartCoroutine(Patton1());
                break;
            case 1:
                IsPattonUse = true;
                StartCoroutine(Patton2());
                break;
            case 2:
                IsPattonUse = true;
                StartCoroutine(Patton3());
                break;
            case 3:
                IsPattonUse = true;
                StartCoroutine(Patton4());
                break;
            case 4:
                IsPattonUse = true;
                StartCoroutine(Patton5());
                break;
            case 5:
                IsPattonUse = true;
                StartCoroutine(Patton6());
                break;
        }
    }
    IEnumerator Patton1()
    {
        for (int z = 80; z < 141; z += 5)
        {
            for(int x = -10; x <= 10; x += 10)
            {
                Instantiate(BossBullet[0], transform.position, Quaternion.Euler(z, 0, x));
            }
        }
        yield return new WaitForSeconds(1);
        for (int z = 80; z < 141; z += 5)
        {
            for (int x = -20; x <= 20; x += 40)
            {
                Instantiate(BossBullet[0], transform.position, Quaternion.Euler(z, 0, x));
            }
        }
        yield return new WaitForSeconds(1);
        for (int z = 80; z < 141; z += 5)
        {
            for (int x = -10; x <= 10; x += 10)
            {
                Instantiate(BossBullet[0], transform.position, Quaternion.Euler(z, 0, x));
            }
        }
        yield return new WaitForSeconds(6);
        IsPattonUse = false;
        yield return null;
    }
    IEnumerator Patton2()
    {
        for (int a = 0; a <= 5; a += 1)
        {
            A = players.transform.position.x * 4;
            Instantiate(BossBullet[1], transform.position, Quaternion.Euler(0, -A, 0));
            yield return new WaitForSeconds(1.3f);
        }
        yield return new WaitForSeconds(4);
        IsPattonUse = false;
        yield return null;
    }
    IEnumerator Patton3()
    {
        for(int a = 0; a <= 750; a += 15)
        {
            for (int b = 0; b <= 360; b += 60)
            {
                Instantiate(BossBullet[0], transform.position, Quaternion.Euler(90, 0, b + a));
            }
            if(a % 150 == 0)
            {
                if(B % 2 == 0)
                {
                    for (int c = 0; c <= 360; c += 15)
                        Instantiate(BossBullet[2], transform.position, Quaternion.Euler(90, 0, c));
                    B++;
                }
                else
                {
                    for (int c = 0; c <= 360; c += 15)
                        Instantiate(BossBullet[3], transform.position, Quaternion.Euler(90, 0, c));
                    B++;
                }
            }
            yield return new WaitForSeconds(0.4f);
        }
        transform.rotation = Quaternion.Euler(0, 0, 0);
        yield return new WaitForSeconds(4);
        IsPattonUse = false;
        yield return null;
    }
    IEnumerator Patton4()
    {
        Instantiate(Enemys[0], transform.position, Quaternion.Euler(0, 0, 0));
        yield return new WaitForSeconds(0.8f);
        for (int a = -2; a < 3; a += 4)
        {
            Instantiate(Enemys[0], transform.position + new Vector3(a, 0, 0), Quaternion.Euler(0, 0, 0));
        }
        yield return new WaitForSeconds(2f);
        for (int a = -3; a < 4; a += 6)
        {
            Instantiate(Enemys[1], transform.position + new Vector3(a, 0, 0), Quaternion.Euler(0, 0, 0));
        }
        yield return new WaitForSeconds(2f);
        Instantiate(Enemys[2], transform.position, Quaternion.Euler(0, 0, 0));
        yield return new WaitForSeconds(9);
        IsPattonUse = false;
        yield return null;
    }
    IEnumerator Patton5()
    {
        Warning.SetActive(true);
        yield return new WaitForSeconds(1);
        Warning.SetActive(false);
        IsPattonMove = true;
        C = 1;
        yield return new WaitForSeconds(3);
        transform.position = new Vector3(5, 10, -17);
        transform.rotation = Quaternion.Euler(0, 180, 0);
        Warning.SetActive(true);
        yield return new WaitForSeconds(1);
        Warning.SetActive(false);
        C = 0;
        yield return new WaitForSeconds(3);
        transform.position = new Vector3(-5, 10, 50);
        transform.rotation = Quaternion.Euler(0, 0, 0);
        Warning.SetActive(true);
        yield return new WaitForSeconds(1);
        Warning.SetActive(false);
        C = 1;
        yield return new WaitForSeconds(3);
        transform.position = new Vector3(0, 25, 15);
        C = 2;
        yield return new WaitForSeconds(4);
        IsPattonUse = false;
        yield return null;
    }
    IEnumerator Patton6()
    {
        for (int a = -9; a <= 9; a += 3)
        {
            Instantiate(BossBullet[4], transform.position + new Vector3(a, 0, 25), Quaternion.Euler(90, 0, 0));
        }
        yield return new WaitForSeconds(1.5f);
        for (float a = -7.5f; a <= 7.5f; a += 3f)
        {
            Instantiate(BossBullet[4], transform.position + new Vector3(a, 0, 25), Quaternion.Euler(90, 0, 0));
        }
        yield return new WaitForSeconds(1.5f);
        for (int a = -9; a <= 9; a += 3)
        {
            Instantiate(BossBullet[4], transform.position + new Vector3(a, 0, 25), Quaternion.Euler(90, 0, 0));
        }
        yield return new WaitForSeconds(3);
        IsPattonUse = false;
        yield return null;
    }
    public override void Move()
    {
        MoveShoot += Time.deltaTime;
        if (C == 0 && transform.position.z < 50) //올라감
        {
            transform.position += new Vector3(0, 0, Speed * Time.deltaTime);
            if(MoveShoot > 0.13f)
            {
                MoveShoot = 0;
                for(int a = -90; a <= 90; a+= 180)
                Instantiate(BossBullet[0], transform.position, Quaternion.Euler(0, 0, a));
            }
        }
        else if(C == 1 && transform.position.z > -17)
        {
            transform.position -= new Vector3(0, 0, Speed * Time.deltaTime);
            if (MoveShoot > 0.13f)
            {
                MoveShoot = 0;
                for (int a = -90; a <= 90; a += 180)
                    Instantiate(BossBullet[0], transform.position, Quaternion.Euler(0, 0, a));
            }
        }    
        else if(C == 2)
        {
            if (transform.position.y <= 10)
            {
                C = 0;
                IsPattonMove = false;
                MoveShoot = 0;
                for (int a = 0; a <= 360; a += 10)
                {
                    Instantiate(BossBullet[0], transform.position, Quaternion.Euler(90, 0, a));
                }
                transform.position = new Vector3(0, 10, 15);
            }
            else
                transform.position -= new Vector3(0, Speed * Time.deltaTime, 0);
        }
    }
    void StartMove()
    {
        if(transform.position.z >= 16)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(0, 10, 15), 6 * Time.deltaTime);
        }
        else
        {
            IsMove = true;
        }
    }

    public override void Dead()
    {
        if (Hp <= 0 && IsDead == false)
        {
            IsDead = true;
            GameManager.Instance.IsBossDead = true;
            GameManager.Instance.IsBossSpawn = true;
            StartCoroutine(DeadEffects());
        }
    }
    IEnumerator DeadEffects()
    {
        Instantiate(DeadEffect).transform.position = transform.position;
        yield return new WaitForSeconds(3);
        Destroy(this.gameObject);
        GameManager.Instance.Score += Score;
        yield return null;
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
        yield return new WaitForSeconds(0.05f);
        mesh.material = material[0];
        yield return null;
    }
}