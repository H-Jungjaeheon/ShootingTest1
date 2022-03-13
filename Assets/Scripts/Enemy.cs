using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float Hp, MaxHp, Damage, Speed, MoveCount, MaxMoveCount;
    [SerializeField] bool IsMove;
    [SerializeField] int LOR;
    Rigidbody rigid;

    // Start is called before the first frame update
    public virtual void Start()
    {
        Hp *= GameManager.Instance.Stage;
        MaxHp *= GameManager.Instance.Stage;
        IsMove = true;
        rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    public virtual void FixedUpdate()
    {
        Move();
        Dead();
    }
    public virtual void Move()
    {
        if(IsMove == true)
        {
            MoveCount += Time.deltaTime;
            transform.position -= new Vector3(0, 0, Speed * Time.deltaTime);
        }
        else
        {
            Turn();
        }
        if (MoveCount >= MaxMoveCount)
        {
            IsMove = false;
            MoveCount = 0;
            StartCoroutine(ChangeX());
        }
    }
    IEnumerator ChangeX()
    {
        LOR = Random.Range(0, 2);
        yield return new WaitForSeconds(1);
        IsMove = true;
        yield return null;
    }
    void Turn()
    {
        if (LOR == 1)
        {        
            if(this.transform.position.x < 8)
            transform.position += new Vector3(3 * Time.deltaTime, 0, 0);   
            else if(this.transform.position.x >= 8)
            transform.position -= new Vector3(3 * Time.deltaTime, 0, 0);
        }
        else
        {          
            if (this.transform.position.x > -8)
            transform.position -= new Vector3(3 * Time.deltaTime, 0, 0);     
            else if(this.transform.position.x <= -8)
            transform.position += new Vector3(3 * Time.deltaTime, 0, 0);
        }
    }
    public virtual void Dead()
    {
        if(Hp <= 0)
        {
            Destroy(this.gameObject);
            //점수 증가
        }
    }
    public virtual void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ObjDestroy"))
        {
            Destroy(this.gameObject);
            //고통지수 증가
        }
        else if (other.gameObject.CompareTag("Bullet") && GameManager.Instance.Hp > 0)
        {
            Hp -= GameManager.Instance.Damage;
            //피격 이벤트 발동
        }
        else if (other.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.Hp -= Damage;
            Destroy(this.gameObject);
        }
    }
}
