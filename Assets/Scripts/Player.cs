using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float Speed, MaxFireTime, FireTime;
    Rigidbody rigid;
    [SerializeField] GameObject Bullet, ShildObj;
    [SerializeField] private GameObject[] BoomObj;
    [SerializeField] private Material[] materials;
    [SerializeField] private MeshRenderer mesh;
    [SerializeField] private bool IsBoom;

    // Start is called before the first frame update
    void Start()
    {
        ShildObj.SetActive(false);
       rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Fire();
        if (Input.GetKeyDown(KeyCode.K) && GameManager.Instance.Boom > 0 && IsBoom == false)
        {
            IsBoom = true;
            Boom();
        }
        //StartCoroutine(PattonTest());
    }
    void FixedUpdate()
    {
        Move();
        Shild();
        BoomObj = GameObject.FindGameObjectsWithTag("Enemy");
    }
    void Move()
    {
        float Horizontal = Speed * Input.GetAxis("Horizontal");
        float Vertical = Speed *  Input.GetAxis("Vertical");
        rigid.velocity = new Vector3(Horizontal, 0, Vertical);
    }
    void Boom()
    {
        for (int a = 0; a < BoomObj.Length; a++)
        {
            BoomObj[a].GetComponent<Enemy>().Hp -= 400;
        }
        IsBoom = false;
        //GameManager.Instance.Boom -= 1;
    }
    void Shild()
    {
        if (Input.GetKeyDown(KeyCode.J) && GameManager.Instance.Shild > 0 && GameManager.Instance.IsShild == false)
        {
            GameManager.Instance.Shild -= 1;
            GameManager.Instance.IsShild = true;
            ShildObj.SetActive(true);
            Invoke("ShildOff", 5f);
        }
    }
    void ShildOff()
    {
        ShildObj.SetActive(false);
        GameManager.Instance.IsShild = false;
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
        if(GameManager.Instance.IsHit == false && GameManager.Instance.IsShild == false)
        {
            if (other.CompareTag("Enemy") || other.CompareTag("EnemyBullet"))
            {
                StartCoroutine(PlayerHit());
                Debug.Log("무적 발동");
            }
        }
    }
    IEnumerator PattonTest()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            for (int z = 0; z < 500; z += 20){ //발사 횟수 및 발사마다 움직일 각도
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
    IEnumerator PlayerHit()
    {
        GameManager.Instance.IsHit = true;
        mesh.material = materials[1];
        yield return new WaitForSeconds(3);
        mesh.material = materials[0];
        GameManager.Instance.IsHit = false;
        yield return null;
    }
}
