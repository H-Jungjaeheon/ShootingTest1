using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Ranking : MonoBehaviour
{
    public static Ranking Instance { get; set; }
    public string[] Name = new string[5];
    public float[] RankScore = new float[5];
    [SerializeField] float NowScore, IsNew;
    public InputField InPuts;

    private void Awake()
    {
        if (IsNew == 0)
        {
            for (int a = 0; a < 5; a++)
            {
                RankScore[a] = 0;
                PlayerPrefs.SetFloat($"Score{a + 1}", RankScore[a]);
            }
        }
        for (int a = 0; a < 5; a++)                                                                                          
        {
            RankScore[a] = PlayerPrefs.GetFloat($"Score{a + 1}");
            Name[a] = PlayerPrefs.GetString($"Name{a + 1}");
        }

        //for (int a = 0; a < 5; a++)
        //{
        //    Name[a] = null;
        //}
    }

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
        IsNew = PlayerPrefs.GetFloat("IsNew");
    }
    // Update is called once per frame
    void Update()
    {
        ScenesMove();
        for(int a = 0; a < 5; a++)
        {
            PlayerPrefs.SetFloat($"Score{a + 1}", RankScore[a]); 
            PlayerPrefs.SetString($"Name{a + 1}", Name[a]);
            PlayerPrefs.Save();
        }
        PlayerPrefs.SetFloat("IsNew", IsNew);

        //for (int a = 0; a < 5; a++) //ÃÊ±âÈ­
        //{
        //    Name[a] = null;
        //    PlayerPrefs.SetFloat($"Score{a + 1}", RankScore[a]);
        //    PlayerPrefs.SetString($"Name{a + 1}", Name[a]);
        //    PlayerPrefs.SetInt("IsNew", 0);
        //    PlayerPrefs.GetFloat($"Score{a + 1}");
        //    PlayerPrefs.GetString($"Name{a + 1}");
        //    PlayerPrefs.GetInt("IsNew");
        //    PlayerPrefs.Save();
        //}
    }
    void ScenesMove()
    {
        if (Input.GetKey(KeyCode.T))
        {
            SceneManager.LoadScene("Ranking");
        }
    }
    public void InputRanking()
    {
        for(int a = 0; a < 5; a++)
        {
            GameManager.Instance.Score = NowScore;
            if(NowScore > RankScore[a])
            {
                Sort(a);
            }
        }
        IsNew++;
        Name[0] = InPuts.text;
        Destroy(InPuts.gameObject);
    }

    void Sort(int i)
    {
        for(int j = i+1; j < 5; j++)
        {

        }
    }
}