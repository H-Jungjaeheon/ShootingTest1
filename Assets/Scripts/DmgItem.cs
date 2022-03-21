using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DmgItem : MonoBehaviour
{
    [SerializeField] private float Speed, Rotation, RSpeed;

    public virtual void Update()
    {
        Move();
    }
    public virtual void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (GameManager.Instance.Damage >= 5)
            {
                GameManager.Instance.Score += 1000;
                GameManager.Instance.Damage = 5;
            }
            else
            {
                GameManager.Instance.Damage += 1;
            }
            //파티클 효과
            Destroy(this.gameObject);
        }
        else if (other.gameObject.CompareTag("Enemy"))
        {

        }
        else if (other.gameObject.CompareTag("ObjDestroy"))
        {
            Destroy(this.gameObject);
        }
    }
    public virtual void Move()
    {
        Rotation += Time.deltaTime * RSpeed;
        transform.position += new Vector3(0, 0, -Speed * Time.deltaTime);
        transform.rotation = Quaternion.Euler(0, Rotation, Rotation);
        if(Rotation >= 360)
        {
            Rotation = 0;
        }
    }
}
