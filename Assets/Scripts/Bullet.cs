using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float Speed;
    [SerializeField] int KindBullet;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        BulletMove();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("ObjDestroy"))
        {
            Destroy(this.gameObject);
        }
    }
    void BulletMove()
    {
        float Z = Speed * Time.deltaTime;
        this.transform.Translate(0, Z, 0);
    }
}
