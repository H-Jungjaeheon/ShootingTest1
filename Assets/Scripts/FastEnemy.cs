using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastEnemy : Enemy
{
    [SerializeField] private GameObject Warining;
    [SerializeField] private float StartMoveCount;

    public override void Start()
    {
        Hp *= GameManager.Instance.Stage + GameManager.Instance.Damage;
        MaxHp *= GameManager.Instance.Stage + GameManager.Instance.Damage;
        IsMove = false;
        rigid = GetComponent<Rigidbody>();
        Invoke("StartMove", StartMoveCount);
    }
    void StartMove()
    {
        IsMove = true;
        Warining.SetActive(false);
    }

    public override void Move()
    {
        if (IsMove == true)
        { 
            transform.position -= new Vector3(0, 0, Speed * Time.deltaTime);
        }
    }
    public override void OnTriggerEnter(Collider other)
    {
        if (IsMove == true)
        {
            base.OnTriggerEnter(other);
        }
    }
}
