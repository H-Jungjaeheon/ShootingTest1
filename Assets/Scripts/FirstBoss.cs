using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstBoss : Enemy
{
    [SerializeField] private bool IsPattonUse;
    public override void Start()
    {
        IsGo = true;
        IsMove = false;
        Hp *= GameManager.Instance.Stage + GameManager.Instance.Damage;
        MaxHp *= GameManager.Instance.Stage + GameManager.Instance.Damage;
        rigid = GetComponent<Rigidbody>();
        mesh = GetComponent<MeshRenderer>();
    }
    // Update is called once per frame
    public override void FixedUpdate()
    {
        if(IsMove == true)
        {
            Move();
        }
        else
        {
            StartMove();
        }
        if(IsPattonUse == false)
        {
            Attack();
        }
        Dead();
        mesh.material = material[0];
    }
    void Attack() //공격 끝난 후 쉬는 타임 존재
    {
        int a = Random.Range(0, 5);
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
        }
    }
    IEnumerator Patton1()
    {

        yield return new WaitForSeconds(3);
        IsPattonUse = false;
        yield return null;
    }
    IEnumerator Patton2()
    {

        yield return new WaitForSeconds(3);
        IsPattonUse = false;
        yield return null;
    }
    IEnumerator Patton3()
    {

        yield return new WaitForSeconds(3);
        IsPattonUse = false;
        yield return null;
    }
    IEnumerator Patton4()
    {

        yield return new WaitForSeconds(3);
        IsPattonUse = false;
        yield return null;
    }
    void StartMove()
    {
        if(transform.position.z >= 15)
        {
            transform.position = Vector3.MoveTowards(transform.position, transform.position - new Vector3(0, 0, 15), 5f);
        }
        else
        {
            IsMove = false;
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
            Destroy(this.gameObject);
            GameManager.Instance.Score += Score;
        }
    }
    public override void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet") && GameManager.Instance.Hp > 0)
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
