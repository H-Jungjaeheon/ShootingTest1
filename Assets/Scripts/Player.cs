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
        //StartCoroutine(PattonTest());
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
            switch (GameManager.Instance.Damage)
            {
                case 1:
                    Instantiate(Bullet, transform.position + new Vector3(0, 0, 1), Quaternion.Euler(90, 0, 0));
                    break;
                case 2:
                    for(float a = -0.5f; a <= 0.5; a += 1f)
                    {
                        Instantiate(Bullet, transform.position + new Vector3(a, 0, 1), Quaternion.Euler(90, 0, 0));
                    }                   
                    break;
                case 3:
                    for (float a = -0.6f; a < 0.7; a += 0.6f)
                    {
                        Instantiate(Bullet, transform.position + new Vector3(a, 0, 1), Quaternion.Euler(90, 0, 0));
                    }
                    break;
                case 4:
                    for (float a = -20f; a <= 40; a += 40f)
                    {
                        Instantiate(Bullet, transform.position + new Vector3(0f, 0, 1), Quaternion.Euler(90, 0, a));
                    }
                    for (float a = -0.6f; a < 0.7; a += 0.6f)
                    {
                        Instantiate(Bullet, transform.position + new Vector3(a, 0, 1), Quaternion.Euler(90, 0, 0));
                    }
                    break;
                case 5:
                    for (float a = -20f; a <= 40; a += 40f)
                    {
                        Instantiate(Bullet, transform.position + new Vector3(0f, 0, 1), Quaternion.Euler(90, 0, a));
                    }
                    for (float a = -0.6f; a < 0.7; a += 0.6f)
                    {
                        Instantiate(Bullet, transform.position + new Vector3(a, 0, 1), Quaternion.Euler(90, 0, 0));
                    }
                    MaxFireTime = 0.2f;
                    break;
            }
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
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy") || other.CompareTag("EnemyBullet"))
        {
            StartCoroutine(PlayerHit());
        }
    }
    IEnumerator PattonTest()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            for (int z = 0; z < 500; z += 20){ //�߻� Ƚ�� �� �߻縶�� ������ ����
                for (int i = 0; i < 360; i += 90) //ȸ����
                {
                    GameObject temp = Instantiate(Bullet, transform.position, Quaternion.Euler(90, 0, i + z));
                    Destroy(temp, 2f);
                }
                yield return new WaitForSeconds(0.1f);
            }

            //for (int i = 0; i < 360; i += 13) //8���� �߻� (i�� ȸ����)
            //{
            //    GameObject temp = Instantiate(Bullet, transform.position, Quaternion.Euler(0, 0, 0));
            //    Destroy(temp, 2f);
            //    temp.transform.rotation = Quaternion.Euler(90, 0, i);
            //}
            //for (int i = 0; i < 360; i += 90) //���ڰ� �߻�
            //{
            //    GameObject temp = Instantiate(Bullet, transform.position, Quaternion.Euler(0, 0, 0));
            //    Destroy(temp, 2f);
            //    temp.transform.rotation = Quaternion.Euler(90, 0, i);
            //}
            //for (int z = 0; z < 360; z += 20) //���ڰ� ȸ�� �߻�
            //{ //�߻� Ƚ��
            //    for (int i = 0; i < 360; i += 90) //ȸ����
            //    {
            //        GameObject temp = Instantiate(Bullet, transform.position, Quaternion.Euler(90, 0, i + z));
            //        Destroy(temp, 2f);
            //    }
            //    yield return new WaitForSeconds(0.2f);
            //}
        }
        yield return null;
    }
    IEnumerator PlayerHit()
    {

        yield return null;
    }
}
