using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class EnemySpawner : MonoBehaviour //전체적 흐름 : 텍스트 파일과 위치를 가져와 함수에 대입, EnemySpawn이라는 함수에 게임 시작될 때 넣어서 
{
    [SerializeField] private GameObject[] Enemy, Spawner;
    [SerializeField] private float SpawnCount, MaxSpawnCount, Spawntime;
    [SerializeField] private int dataIdx; //텍스트 줄 판별
    private bool isReadEnemyData, isEndEnemyData; // , 다 소환시 업데이트 반복 멈추는 변수
    private List<EnemyData> Enemydata = new List<EnemyData>(); //텍스트로 생성할 형식 클래스 리스트로 받기


    // Start is called before the first frame update
    void Start()
    {
        dataIdx = 0;
        EnemySpawn(Resources.Load<TextAsset>($"Stage{GameManager.Instance.Stage}Text").text); //리소스파일에 있는 텍스트를 가져옴
    }
    void Update()
    {
        if (Time.time >= Spawntime && isReadEnemyData && isEndEnemyData == false)
        {
            SpawnEnemy();
            dataIdx++;
            if (dataIdx == Enemydata.Count) //리스트 안 요쇼와 줄 판별이 같으면 종료
            {
                isEndEnemyData = true;
                return;
            }
            Spawntime = Time.time + Enemydata[dataIdx].SpawnTime;
        }
        Spawn();
    }
   
    void EnemySpawn(string SpawnText)
    {
        Enemydata.Clear(); //리스트 초기화
        var stringReader = new StringReader(SpawnText); //파일을 읽는 StringReader를 선언 (스폰 텍스트 받아옴)

        while (true) //텍스트 줄만큼 읽기(반복)
        {
            string lineText = stringReader.ReadLine(); //한줄 단위로 나눠서 읽는 ReadLine선언
            if (lineText == null) break; //받아온 텍스트가 끝난다면 반복 종료

            string[] splitText = lineText.Split(','); //,를 기준으로 배열에다가 값을 넣음

            var enemyData = new EnemyData();
            enemyData.SpawnTime = int.Parse(splitText[0]);
            enemyData.EnemyKind = int.Parse(splitText[1]);
            enemyData.Spawners = int.Parse(splitText[2]);

            Enemydata.Add(enemyData);
        }

        stringReader.Close();

        Spawntime = Time.time + Enemydata[dataIdx].SpawnTime;
        isReadEnemyData = true;
    }
    private void SpawnEnemy()
    {
        Vector3 spawnPos = Spawner[Enemydata[dataIdx].Spawners].transform.position;
        switch (Enemydata[dataIdx].EnemyKind)
        {
            case 0: Instantiate(Enemy[0], spawnPos, Enemy[0].transform.rotation); break;
            case 1: Instantiate(Enemy[1], spawnPos, Enemy[1].transform.rotation); break;
            case 2: Instantiate(Enemy[2], spawnPos, Enemy[2].transform.rotation); break;
            case 3: Instantiate(Enemy[3], spawnPos, Enemy[3].transform.rotation); break;
            case 4: Instantiate(Enemy[4], spawnPos, Enemy[4].transform.rotation); break;
            case 5: Instantiate(Enemy[5], spawnPos, Enemy[5].transform.rotation); break;
            case 6: Instantiate(Enemy[6], spawnPos, Enemy[6].transform.rotation); break;
        }
    }
    void Spawn()
    {
        if(GameManager.Instance.Cutscene == false)
        {
            SpawnCount += Time.deltaTime;
            if (SpawnCount >= MaxSpawnCount)
            {
                MaxSpawnCount = Random.Range(6, 12);
                SpawnCount = 0;
                int a = Random.Range(0, 10);
                int b = Random.Range(0, 5);
                if (a >= 5)
                    Instantiate(Enemy[7], Spawner[b].transform.position, transform.rotation);
                else if (a < 5)
                    Instantiate(Enemy[8], Spawner[b].transform.position, transform.rotation);
            }
        } 
    }
}
