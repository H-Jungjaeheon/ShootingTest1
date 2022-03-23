using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedCell : MonoBehaviour
{
    [SerializeField] private float Speed, Rotation, RSpeed, Hp;
    [SerializeField] private Material[] materials;
    [SerializeField] private MeshRenderer MR;
    [SerializeField] private bool IsHIt;
    private void Start()
    {
        MR = GetComponent<MeshRenderer>();
    }
    private void Update()
    {
        Move();
        if(Hp <= 0)
        {
            //파티클 효과
            GameManager.Instance.Pain += 10;
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy") && IsHIt == false)
        {
            StartCoroutine(Hits());        
            Hp -= 1;
        }
        else if (other.gameObject.CompareTag("EnemyBullet") && IsHIt == false)
        {
            StartCoroutine(Hits());
            Hp -= 1;
        }
        else if (other.gameObject.CompareTag("ObjDestroy"))
        {
            GameManager.Instance.Pain -= 15;
            Destroy(this.gameObject);
        }
    }
    public virtual IEnumerator Hits()
    {
        IsHIt = true;
        MR.material = materials[1];
        yield return new WaitForSeconds(0.8f);
        MR.material = materials[0];
        IsHIt = false;
        yield return null;
    }
    public virtual void Move()
    {
        Rotation += Time.deltaTime * RSpeed;
        transform.position += new Vector3(0, 0, -Speed * Time.deltaTime);
        transform.rotation = Quaternion.Euler(0, Rotation, -60);
        if (Rotation >= 360)
        {
            Rotation = 0;
        }
    }
}
