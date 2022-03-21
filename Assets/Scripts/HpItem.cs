using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpItem : DmgItem
{
    [SerializeField] private float HealHp;
    public override void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (GameManager.Instance.Damage >= GameManager.Instance.MaxHp)
            {
                GameManager.Instance.Score += 1000;
            }
            else
            {
                GameManager.Instance.Hp += HealHp;
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
