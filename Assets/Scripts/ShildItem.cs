using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShildItem : DmgItem
{
    public override void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (GameManager.Instance.Shild >= GameManager.Instance.MaxShild)
            {
                GameManager.Instance.Score += 1400;
            }
            else
            {
                GameManager.Instance.Shild += 1;
            }
            //��ƼŬ ȿ��
            Destroy(this.gameObject);
        }
        else if (other.gameObject.CompareTag("ObjDestroy"))
        {
            Destroy(this.gameObject);
        }
    }
}
