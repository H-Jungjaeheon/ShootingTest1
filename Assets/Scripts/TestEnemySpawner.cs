using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class TestEnemySpawner : MonoBehaviour
{
    [SerializeField] private bool End, Read;
    [SerializeField] private int DataIndex;
    [SerializeField] private float SpawnTime;
    private List<EnemyData> Enemydata = new List<EnemyData>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
