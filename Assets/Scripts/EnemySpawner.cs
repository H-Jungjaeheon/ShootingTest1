using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] Enemy, Spawner;
    [SerializeField] private float SpawnCount, MaxSpawnCount, Spawntime;
    [SerializeField] private int dataIdx; //
    private bool isReadEnemyData, isEndEnemyData; //
    private List<EnemyData> Enemydata = new List<EnemyData>(); //�ؽ�Ʈ�� ������ ���� Ŭ���� ����Ʈ�� �ޱ�


    // Start is called before the first frame update
    void Start()
    {
        dataIdx = 0; //�ؽ�Ʈ �� �Ǻ�?
        //Spawn();
        EnemySpawn(Resources.Load<TextAsset>($"Stage{GameManager.Instance.Stage}Text").text); //���ҽ����Ͽ� �ִ� �ؽ�Ʈ�� ������
    }
    void Update()
    {
        if (Time.time >= Spawntime && isEndEnemyData == false)
        {
            SpawnEnemy();
            dataIdx++;
            if (dataIdx == Enemydata.Count)
            {
                isEndEnemyData = true;
                return;
            }
            Spawntime = Time.time + Enemydata[dataIdx].SpawnTime;
        }
    }
   
    void EnemySpawn(string SpawnText)
    {
        Enemydata.Clear(); //����Ʈ �ʱ�ȭ
        var stringReader = new StringReader(SpawnText); //������ �д� StringReader�� ���� (���� �ؽ�Ʈ �޾ƿ�)
        Debug.Assert(stringReader != null);

        while (true) //�ؽ�Ʈ �ٸ�ŭ �б�(�ݺ�)
        {
            string lineText = stringReader.ReadLine(); //���� ������ ������ �д� ReadLine����
            if (lineText == null) break; //�޾ƿ� �ؽ�Ʈ�� �����ٸ� �ݺ� ����

            string[] splitText = lineText.Split(','); //,�� �������� �迭���ٰ� ���� ����

            var enemyData = new EnemyData();
            enemyData.SpawnTime = float.Parse(splitText[0]);
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
            case 7: Instantiate(Enemy[7], spawnPos, Enemy[7].transform.rotation); break;
            default: Debug.Assert(false); break;
        }
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
