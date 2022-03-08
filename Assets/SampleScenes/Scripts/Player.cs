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
        float Horizontals = Input.GetAxis("Horizontal");
        float Verticals = Input.GetAxis("Vertical");
        Vector3 Position = transform.position;
        Position.x += Speed * Horizontals * Time.deltaTime;
        Position.y += Speed * Verticals * Time.deltaTime;
        transform.position = Position;
    }
}
