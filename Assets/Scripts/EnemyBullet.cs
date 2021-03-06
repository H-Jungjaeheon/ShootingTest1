using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float Speed, Damage;
    [SerializeField] private GameObject BulletParticle;
    // Start is called before the first frame update
    public virtual void Start()
    {
        Damage = GameManager.Instance.Stage * Damage;
    }

    // Update is called once per frame
    public virtual void Update()
    {
        BulletMove();
    }
    public virtual void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if(GameManager.Instance.IsHit == false && GameManager.Instance.IsShild == false)
            {
                GameManager.Instance.Hp -= Damage;
            }
            Destroy(this.gameObject);
        }
        else if (other.gameObject.CompareTag("ObjDestroy") || other.gameObject.CompareTag("RedCell"))
        {
            Instantiate(BulletParticle).transform.position = transform.position;
            Destroy(this.gameObject);
        }
    }
    public virtual void BulletMove()
    {
        float Z = Speed * Time.deltaTime;
        this.transform.Translate(0, -Z, 0);
    }
}
