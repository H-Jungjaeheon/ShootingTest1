using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShildItem : DmgItem
{
    public override void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.ShildTime = 3;
            //��ƼŬ ȿ��
            Destroy(this.gameObject);
        }
        else if (other.gameObject.CompareTag("ObjDestroy"))
        {
            Destroy(this.gameObject);
        }
    }
}
