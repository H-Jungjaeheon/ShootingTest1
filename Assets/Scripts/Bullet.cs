using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float Speed;
    [SerializeField] private GameObject Effect;
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
            if (other.gameObject.CompareTag("ObjDestroy"))
            {
                Instantiate(Effect).transform.position = transform.position;
            }
            Destroy(this.gameObject);
        }
    }
    void BulletMove()
    {
        float Z = Speed * Time.deltaTime;
        this.transform.Translate(0, Z, 0);
    }
}
