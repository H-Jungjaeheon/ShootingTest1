using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastEnemy : Enemy
{
    [SerializeField] private GameObject Warining;
    [SerializeField] private float StartMoveCount;

    public override void Awake()
    {
        IsGo = false;
        Hp *= GameManager.Instance.Stage + GameManager.Instance.Damage;
        MaxHp *= GameManager.Instance.Stage + GameManager.Instance.Damage;
        IsMove = true;
        rigid = GetComponent<Rigidbody>();
        mesh = GetComponent<MeshRenderer>();
        Invoke("StartMove", StartMoveCount);
        Damage *= GameManager.Instance.Stage;
    }
    void StartMove()
    {
        IsGo = true;
        Warining.SetActive(false);
    }

    public override void Move()
    {
        if (IsGo == true)
        { 
            transform.position -= new Vector3(0, 0, Speed * Time.deltaTime);
        }
    }
    public override void OnTriggerEnter(Collider other)
    {
        if (IsGo == true)
        {
            if (other.gameObject.CompareTag("ObjDestroy"))
            {
                Destroy(this.gameObject);
                GameManager.Instance.Pain += 1;
            }
            else if (other.gameObject.CompareTag("Bullet") && GameManager.Instance.Hp > 0)
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
                Destroy(this.gameObject);
            }
        }
    }
}
