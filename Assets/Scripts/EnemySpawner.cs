using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject[] Enemy, Spawner;
    [SerializeField] float SpawnCount, MaxSpawnCount;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Spawn();
    }
    void Spawn()
    {
        SpawnCount += Time.deltaTime;
        if(SpawnCount >= MaxSpawnCount)
        {
            SpawnCount = 0;
            int a = Random.Range(0, 3);
            int b = Random.Range(0, 5);
            Instantiate(Enemy[a], Spawner[b].transform.position, transform.rotation);
        }
    }
}
