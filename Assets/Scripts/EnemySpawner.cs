using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] Enemy, Spawner;
    [SerializeField] private float SpawnCount, MaxSpawnCount, Spawntime;
    [SerializeField] private int dataIdx;
    [SerializeField] private string SpawnText;
    private bool isReadEnemyData;
    private List<EnemyData> Enemydata = new List<EnemyData>();


    // Start is called before the first frame update
    void Start()
    {
        dataIdx = 0;
        Spawn();
        SpawnText = Resources.Load<TextAsset>($"Stage{GameManager.Instance.Stage}Text").text;
        EnemySpawn(SpawnText);
    }

    void Update()
    {
        if (Time.time >= Spawntime && isReadEnemyData && isReadEnemyData == false)
        {
            SpawnEnemy();
            dataIdx++;
            if (dataIdx == Enemydata.Count)
            {
                isReadEnemyData = true;
                return;
            }

            Spawntime = Time.time + Enemydata[dataIdx].SpawnTime;
        }
    }
   
    void EnemySpawn(string SpawnText)
    {
        Enemydata.Clear();
        var stringReader = new StringReader(SpawnText);

        while (true)
        {
            string lineText = stringReader.ReadLine();
            if (lineText == null) break;

            string[] splitText = lineText.Split(',');

            var enemyData = new EnemyData();
            enemyData.SpawnTime = float.Parse(splitText[0]);
            enemyData.EnemyKind = float.Parse(splitText[1]);
            enemyData.Spawners = float.Parse(splitText[2]);

            Enemydata.Add(enemyData);
        }

        stringReader.Close();

        Spawntime = Time.time + Enemydata[dataIdx].SpawnTime;
        isReadEnemyData = true;
    }
    void Spawn()
    {
        SpawnCount += Time.deltaTime;
        if(SpawnCount >= MaxSpawnCount)
        {
            SpawnCount = 0;
            int a = Random.Range(0, 9);
            int b = Random.Range(0, 5);
            Instantiate(Enemy[a], Spawner[b].transform.position, transform.rotation);
        }
    }
    private void SpawnEnemy()
    {
        Vector3 spawnPos = Spawner[Enemy[dataIdx].Spawners - 1].position;

        switch (Enemy[dataIdx].EnemyKind)
        {
            case "bacteria": Instantiate(bacteria, spawnPos, bacteria.transform.rotation); break;
            case "virus": Instantiate(virus, spawnPos, bacteria.transform.rotation); break;
            case "cancer": Instantiate(cancer, spawnPos, bacteria.transform.rotation); break;
            default: Debug.Assert(false); break;
        }
    }
}
