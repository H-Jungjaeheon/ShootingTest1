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
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("ObjDestroy"))
        {
            GameManager.Instance.Hp -= Damage;
            Destroy(this.gameObject);
        }
    }
    void BulletMove()
    {
        float Z = Speed * Time.deltaTime;
        this.transform.Translate(0, -Z, 0);
    }
}
