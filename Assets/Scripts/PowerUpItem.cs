using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpItem : MonoBehaviour
{
    [SerializeField] float Speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public virtual void FixedUpdate()
    {
        Move();
    }
    public virtual void Move()
    {
        float Z = Speed * Time.deltaTime;
        transform.position += new Vector3(0, 0, Z);
    }
    public virtual void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.Damage += 1;
            Destroy(this.gameObject);
            //∏‘¿ª ∂ß¿« ¿Ã∆Â∆Æ
        }
    }
}
