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
    [SerializeField] private GameObject Obj;
    //[SerializeField] string NowName;
    public InputField InPuts;

    private void Awake()
    {
        //if (IsNew == 0)
        //{
        //    for (int a = 0; a < 5; a++)
        //    {
        //        RankScore[a] = 0;
        //        PlayerPrefs.SetFloat($"Score{a + 1}", RankScore[a]);
        //    }
        //}
        //for (int a = 0; a < 5; a++)                                                                                          
        //{
        //    RankScore[a] = PlayerPrefs.GetFloat($"Score{a + 1}");
        //    Name[a] = PlayerPrefs.GetString($"Name{a + 1}");
        //}
    }

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
        //IsNew = PlayerPrefs.GetFloat("IsNew");
    }
    // Update is called once per frame
    void Update()
    {
        ScenesMove();
        //for (int a = 0; a < 5; a++)
        //{
        //    PlayerPrefs.SetFloat($"Score{a + 1}", RankScore[a]); 
        //    PlayerPrefs.SetString($"Name{a + 1}", Name[a]);
        //    PlayerPrefs.Save();
        //}
        //PlayerPrefs.SetFloat("IsNew", IsNew);
        if (SceneManager.GetActiveScene().name == "Ranking")
        {
            NowScore = GameManager.Instance.Score;
        }

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
        if (SceneManager.GetActiveScene().name == "Ranking")
        {
            Obj.SetActive(true);
        }
        else
        {
            Obj.SetActive(false);
        }
    }
    public void InputRanking()
    {
        if (NowScore > RankScore[0])
           SuperSort(0);
        else if(NowScore > RankScore[4] && NowScore < RankScore[3])
           SuperSort(4);
        else
        {
            for (int a = 1; a < 4; a++)
            {
                if (NowScore > RankScore[a] && NowScore < RankScore[a - 1])
                {
                    Sort(a);
                }
            }
        }
        IsNew++;
        //Destroy(InPuts.gameObject);
    }
    void SuperSort(int i)
    {
        if(i == 0)
        {
            for (int j = 4; j > 0; j--)
            {
                RankScore[j] = RankScore[j - 1];
                Name[j] = Name[j - 1];
            }
            Name[i] = InPuts.text;
            RankScore[i] = NowScore;
            NowScore = 0;
            InPuts.text = "";
        }
        else
        {
            Name[i] = InPuts.text;
            RankScore[i] = NowScore;
            NowScore = 0;
            InPuts.text = "";
        }
    }

    void Sort(int i)
    {
        for(int j = 4; j > i; j--)
        {
            Name[j] = Name[j - 1];
            RankScore[j] = RankScore[j - 1];
        }
        Name[i] = InPuts.text;
        RankScore[i] = NowScore;
        NowScore = 0;
        InPuts.text = "";
    }
}