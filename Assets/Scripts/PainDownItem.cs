using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PainDownItem : DmgItem
{
    [SerializeField] private float PainDown;
    // Update is called once per frame
    public override void Update()
    {
        base.Update();   
    }
    public override void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.Pain -= PainDown;
            //��ƼŬ ȿ��
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
