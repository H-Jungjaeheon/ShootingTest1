using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomColider : MonoBehaviour
{
    [SerializeField] private GameObject[] Enemys;
    private void Start()
    {
        //enemy = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Enemy>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            Enemys = GameObject.FindGameObjectsWithTag("Enemy");
            for (int a = 0; a < Enemys.Length; a++)
            {
                Enemys[a].GetComponent<Enemy>().Hp -= 40;
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        
    }
}
