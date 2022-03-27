using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankerEnemy : Enemy
{
    [SerializeField] private float RandReflect;
    [SerializeField] private GameObject ReflectBullet;
    public override void Move()
    {
        transform.position -= new Vector3(0, 0, Speed * Time.deltaTime);
    }
    public override void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ObjDestroy"))
        {
            Destroy(this.gameObject);
            GameManager.Instance.Pain += Damage;
        }
        else if (other.gameObject.CompareTag("Bullet") && GameManager.Instance.Hp > 0)
        {
            RandReflect = Random.Range(1, 5);
            if(RandReflect == 1)
            {
                float a = Random.Range(-40, 41);
                Instantiate(ReflectBullet, transform.position, Quaternion.Euler(90, 0, a));
                RandReflect = 0;
            }
            else
            {
                Hp -= GameManager.Instance.Damage;
                StartCoroutine(EnemyHit());
            }
        }
        else if (other.gameObject.CompareTag("Player"))
        {
            if(GameManager.Instance.IsHit == false && GameManager.Instance.IsShild == false)
            {
                GameManager.Instance.Hp -= Damage;
            }
            Destroy(this.gameObject);
        }
    }
}
