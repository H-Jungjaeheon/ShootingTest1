using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float Speed;
    Rigidbody rigid;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
