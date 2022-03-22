using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllStatUpItem : DmgItem
{
    [SerializeField] private float MaxCount;
    [SerializeField] private Player player;
    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
    }
    public override void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.MaxHp += 10;
            if (GameManager.Instance.Damage >= 5)
            {
                MaxCount += 1;
            }
            else
            {
                GameManager.Instance.Damage++;
            }
            if(player.Speed >= 15)
            {
                MaxCount += 1;
            }
            else
            {
                player.Speed += 1;
            }
            ScorePlus();
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
    void ScorePlus()
    {
        GameManager.Instance.Score += MaxCount * 700;
    }
}
