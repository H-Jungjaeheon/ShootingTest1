using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] float Speed, Damage;
    // Start is called before the first frame update
    void Start()
    {
        Damage = GameManager.Instance.Stage * Damage;
    }

    // Update is called once per frame
    void Update()
    {
        BulletMove();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if(GameManager.Instance.IsHit == false && GameManager.Instance.IsShild == false)
            {
                GameManager.Instance.Hp -= Damage;
            }
            Destroy(this.gameObject);
        }
        else if (other.gameObject.CompareTag("ObjDestroy"))
        {
            Destroy(this.gameObject);
        }
    }
    void BulletMove()
    {
        float Z = Speed * Time.deltaTime;
        this.transform.Translate(0, -Z, 0);
    }
}
