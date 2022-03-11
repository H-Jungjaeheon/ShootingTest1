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
        CircleShot();
    }
    void FixedUpdate()
    {
        Move();
    }
    void Move()
    {
        float Horizontal = Speed * Input.GetAxis("Horizontal");
        float Vertical = Speed *  Input.GetAxis("Vertical");
        rigid.velocity = new Vector3(Horizontal, 0, Vertical);
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
    void CircleShot()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            for (int i = 0; i < 360; i += 13)
            {
                GameObject temp = Instantiate(Bullet);
                Destroy(temp, 2f);
                temp.transform.position = Vector3.zero;
                temp.transform.rotation = Quaternion.Euler(0, 0, i);
            }
        }
    }
}
