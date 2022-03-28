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
    private List<EnemyData> Enemydata = new List<EnemyData>(); //텍스트로 생성할 형식 클래스 리스트로 받기


    // Start is called before the first frame update
    void Start()
    {
        dataIdx = 0;
        //Spawn();
        SpawnText = Resources.Load<TextAsset>($"Stage{GameManager.Instance.Stage}Text").text; //스트링으로 선언한 변수 안에 리소스파일에 있는 텍스트를 가져옴
        EnemySpawn(SpawnText); //받아온 텍스트를 가지고 함수로 들어감
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
        Enemydata.Clear(); //리스트 초기화
        var stringReader = new StringReader(SpawnText); //파일을 읽는 StringReader를 선언 (스폰 텍스트 받아옴)

        while (true) //무한반복
        {
            string lineText = stringReader.ReadLine(); //한줄 단위로 나눠서 읽는 ReadLine선언
            if (lineText == null) break; //받아온 텍스트가 끝난다면 반복 종료

            string[] splitText = lineText.Split(','); //,를 기준으로 배열에다가 값을 넣음

            var enemyData = new EnemyData();
            enemyData.SpawnTime = float.Parse(splitText[0]);
            enemyData.EnemyKind = float.Parse(splitText[1]);
            enemyData.Spawners = int.Parse(splitText[2]);

            Enemydata.Add(enemyData);
        }

        stringReader.Close();

        Spawntime = Time.time + Enemydata[dataIdx].SpawnTime;
        isReadEnemyData = true;
    }
    private void SpawnEnemy()
    {
        Vector3 spawnPos = Spawner[Enemydata[dataIdx].Spawners - 1].transform.position;

        switch (Enemydata[dataIdx].EnemyKind)
        {
            case "bacteria": Instantiate(bacteria, spawnPos, bacteria.transform.rotation); break;
            case "virus": Instantiate(virus, spawnPos, bacteria.transform.rotation); break;
            case "cancer": Instantiate(cancer, spawnPos, bacteria.transform.rotation); break;
        }

        nowSpawnTime = Enemydata[dataIdx].SpawnTime;
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
}
