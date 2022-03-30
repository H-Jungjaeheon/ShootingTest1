using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplitEnemy : Enemy
{
    [SerializeField] private GameObject MiniObj;
    [SerializeField] private bool IsSpawnMini;
    [SerializeField] private int MonsterCount;

    public override void Dead()
    {
        if (Hp <= 0)
        {
            if (IsSpawnMini == true)
            {
                if (MonsterCount == 2)
                {
                    for (float a = -1.2f; a < 1.3f; a += 2.4f)
                    {
                        Instantiate(MiniObj, transform.position + new Vector3(a, 0, 0), Quaternion.Euler(0, 0, 0));
                    }
                }
                else
                {
                    for (float a = -0.9f; a < 1f; a += 1.8f)
                    {
                        Instantiate(MiniObj, transform.position + new Vector3(a, 0, 0), Quaternion.Euler(0, 0, 0));
                    }
                }
            }
            Instantiate(DeadEffect).transform.position = transform.position;
            if (GameManager.Instance.IsBossSpawn == false && IsSpawnMini == true)
            {
                GameManager.Instance.EnemyDead += 3;
                GameManager.Instance.Score += Score;

            }
            else if(GameManager.Instance.IsBossSpawn == true && IsSpawnMini == true)
                GameManager.Instance.EnemyDead+=3;
            else if (GameManager.Instance.IsBossSpawn == false && IsSpawnMini == false)
                GameManager.Instance.EnemyDead ++;
            else
                GameManager.Instance.EnemyDead++;
            Destroy(this.gameObject);
        }
    }
    public override IEnumerator EnemyHit()
    {
        mesh.material = material[1];
        yield return new WaitForSeconds(0.5f);
        mesh.material = material[0];
        yield return null;
    }
}
