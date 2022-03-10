using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float Speed, MaxFireTime, FireTime;
    Rigidbody rigid;
    [SerializeField] GameObject Bullet;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Fire();
    }
    void FixedUpdate()
    {
        Move();
    }
    void Move()
    {
        float Horizontal = Speed * Time.deltaTime * Input.GetAxis("Horizontal");
        float Vertical = Speed * Time.deltaTime * Input.GetAxis("Vertical");
        transform.Translate(Horizontal, 0, Vertical);
        rigid.velocity = Vector3.zero;
        rigid.angularVelocity = Vector3.zero;
    }
    void Fire()
    {
        if (Input.GetKey(KeyCode.H) && FireTime == 0)
        {
            Instantiate(Bullet, transform.position + new Vector3(0,0,2), Quaternion.Euler(90, 0, 0));
            FireTime += MaxFireTime;
        }
        if (FireTime > 0)
        {
            FireTime -= Time.deltaTime;
        }
        else if (FireTime < 0)
        {
            FireTime = 0;
        }
    }
}
