using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedItem : DmgItem
{
    [SerializeField] private Player player;
    public float a = 0;

    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
    }

    public override void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if(player.Speed >= 15)
            { 
                GameManager.Instance.Score += 1000;
                player.Speed = 15;
            }
            else
            {
                a = player.Speed;
                player.Speed += 1;
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
