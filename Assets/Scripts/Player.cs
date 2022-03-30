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
        if (Input.GetKeyDown(KeyCode.J) && GameManager.Instance.Boom > 0 && IsBoom == false && BoomObj != null)
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
        if (GameManager.Instance.Cutscene == false)
        {
            float Horizontal = Speed * Input.GetAxis("Horizontal");
            float Vertical = Speed * Input.GetAxis("Vertical");
            rigid.velocity = new Vector3(Horizontal, 0, Vertical);
        }
    }
    void Boom()
    {
        //if (GameManager.Instance.Cutscene == false)
            for (int a = 0; a < BoomObj.Length; a++)
            {
                //if(BoomObj[a].GetComponent<Enemy>().IsGo == true)
                BoomObj[a].GetComponent<Enemy>().Hp -= GameManager.Instance.Damage * 10;
            }
            IsBoom = false;
            GameManager.Instance.Boom -= 1;
    }
    void Shild()
    {
        if (GameManager.Instance.ShildTime > 0)
        {
            ShildObj.SetActive(true);
            GameManager.Instance.IsShild = true;
        }
        else if(GameManager.Instance.ShildTime <= 0)
        {
            ShildObj.SetActive(false);
            GameManager.Instance.IsShild = false;
            GameManager.Instance.ShildTime = 0;
        }
        if(GameManager.Instance.ShildTime > 0.5)
        {
            //파티클 실행
            Debug.Log("실드 파티클 활성화");
        }
        else
        {
            //파티클 종료
        }
    }
    IEnumerator ShildOff(float ShildTime)
    {
        yield return new WaitForSeconds(ShildTime - 0.5f);
        ShildObj.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        GameManager.Instance.IsShild = false;
        yield return null;
    }
    private void CutScenePosition()
    {
        transform.position = new Vector3(0, 10, -10f);
    }
    private void Fire()
    {
        if (Input.GetKey(KeyCode.H) && FireTime == 0 && GameManager.Instance.Cutscene == false)
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
                    MaxFireTime = 0.1f;
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
        if(GameManager.Instance.IsHit == false && GameManager.Instance.IsShild == false && GameManager.Instance.Cutscene == false)
        {
            if (other.CompareTag("Enemy") || other.CompareTag("EnemyBullet"))
            {
                StartCoroutine(PlayerHit());
                Debug.Log("무적 발동");
            }
        }
    }
    IEnumerator PlayerHit()
    {
        if(GameManager.Instance.Cutscene == false)
        {
            GameManager.Instance.IsHit = true;
            //GameManager.Instance.DamageShake();
            GameManager.Instance.Source.GenerateImpulse();
            mesh.material = materials[1];
            yield return new WaitForSeconds(3);
            mesh.material = materials[0];
            GameManager.Instance.IsHit = false;
            yield return null;
        }
    }
}
