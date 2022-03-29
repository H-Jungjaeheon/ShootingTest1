using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteCell : MonoBehaviour
{
    [SerializeField] private float Speed, Rotation, RSpeed, Hp;
    [SerializeField] private Material[] materials;
    [SerializeField] private MeshRenderer MR;
    [SerializeField] private GameObject[] Item;

    private void Start()
    {
        MR = GetComponent<MeshRenderer>();
    }
    private void Update()
    {
        Move();
        Dead();
    }
    private void Dead()
    {
        if (Hp <= 0)
        {
            int a = Random.Range(0, 9);
            //파티클 효과
            if(a > 6)
            Instantiate(Item[2], transform.position, Quaternion.Euler(0, 0, 0));     
            else
            Instantiate(Item[a], transform.position, Quaternion.Euler(0, 0, 0));
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            StartCoroutine(Hits());
            Hp -= 1;
        }
        else if (other.gameObject.CompareTag("ObjDestroy"))
        {
            Destroy(this.gameObject);
        }
    }
    private IEnumerator Hits()
    {
        MR.material = materials[1];
        yield return new WaitForSeconds(0.8f);
        MR.material = materials[0];
        yield return null;
    }
    private void Move()
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
