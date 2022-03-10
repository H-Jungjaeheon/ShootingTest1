using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundScroll : MonoBehaviour
{
    [SerializeField] float MoveSpeed;
    [SerializeField] GameObject[] BackGround;
    
    void Start()
    {
        
    }
    void Update()
    {
        ScrollMove();
    }
    void ScrollMove()
    {
        float Z = MoveSpeed * Time.deltaTime;
        BackGround[0].transform.Translate(0, 0, Z);
        BackGround[1].transform.Translate(0, 0, Z);
        if (BackGround[0].transform.position.z <= BackGround[2].transform.position.z)
        {
            BackGround[0].transform.position = BackGround[3].transform.position;
        }
        else if (BackGround[1].transform.position.z <= BackGround[2].transform.position.z)
        {
            BackGround[1].transform.position = BackGround[3].transform.position;
        }
    }
}
