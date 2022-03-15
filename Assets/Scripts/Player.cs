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
        StartCoroutine(PattonTest());
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
    IEnumerator PattonTest()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            for (int z = 0; z < 500; z += 20){ //발사 횟수
                for (int i = 0; i < 360; i += 90) //회전값
                {
                    GameObject temp = Instantiate(Bullet, transform.position, Quaternion.Euler(90, 0, i + z));
                    Destroy(temp, 2f);
                }
                yield return new WaitForSeconds(0.1f);
            }

            //for (int i = 0; i < 360; i += 13) //8방향 발사 (i는 회전값)
            //{
            //    GameObject temp = Instantiate(Bullet, transform.position, Quaternion.Euler(0, 0, 0));
            //    Destroy(temp, 2f);
            //    temp.transform.rotation = Quaternion.Euler(90, 0, i);
            //}
            //for (int i = 0; i < 360; i += 90) //십자가 발사
            //{
            //    GameObject temp = Instantiate(Bullet, transform.position, Quaternion.Euler(0, 0, 0));
            //    Destroy(temp, 2f);
            //    temp.transform.rotation = Quaternion.Euler(90, 0, i);
            //}
            //for (int z = 0; z < 360; z += 20) //십자가 회전 발사
            //{ //발사 횟수
            //    for (int i = 0; i < 360; i += 90) //회전값
            //    {
            //        GameObject temp = Instantiate(Bullet, transform.position, Quaternion.Euler(90, 0, i + z));
            //        Destroy(temp, 2f);
            //    }
            //    yield return new WaitForSeconds(0.2f);
            //}
        }
        yield return null;
    }
}
