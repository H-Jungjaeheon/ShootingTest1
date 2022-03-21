using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float Hp, MaxHp, Damage, Speed, MoveCount, MaxMoveCount, Score;
    public bool IsMove;
    [SerializeField] private int LOR;
    public Material[] material;
    public Rigidbody rigid;
    public MeshRenderer mesh;

    // Start is called before the first frame update
    public virtual void Start()
    {
        Hp *= GameManager.Instance.Stage + GameManager.Instance.Damage;
        MaxHp *= GameManager.Instance.Stage + GameManager.Instance.Damage;
        IsMove = true;
        rigid = GetComponent<Rigidbody>();
        mesh = GetComponent<MeshRenderer>();
    }
    // Update is called once per frame
    public virtual void FixedUpdate()
    {
        Move();
        Dead();
        mesh.material = material[0];
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
    public virtual IEnumerator ChangeX()
    {
        LOR = Random.Range(0, 2);
        yield return new WaitForSeconds(1);
        IsMove = true;
        yield return null;
    }
    public virtual void Turn()
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
            GameManager.Instance.Score += Score;
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
            StartCoroutine(EnemyHit());
        }
        else if (other.gameObject.CompareTag("Player"))
        {
            if(GameManager.Instance.IsHit == false)
            {
                GameManager.Instance.Hp -= Damage;
            }
            Destroy(this.gameObject);
        }
    }
    
    public virtual IEnumerator EnemyHit()
    {
        mesh.material = material[1];
        yield return new WaitForSeconds(0.5f);
        mesh.material = material[0];
        yield return null;
    }
}
