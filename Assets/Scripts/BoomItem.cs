using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomItem : DmgItem
{
    public override void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (GameManager.Instance.Boom >= GameManager.Instance.MaxBoom)
            {
                GameManager.Instance.Score += 1700;
            }
            else
            {
                GameManager.Instance.Boom += 1;
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
}
