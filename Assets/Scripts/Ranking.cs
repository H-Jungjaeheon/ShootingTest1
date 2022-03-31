using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ranking : MonoBehaviour
{
    public static Ranking Instance { get; set; }
    public string[] Name = new string[5];
    public float[] RankScore = new float[5];

    private void Awake()
    {
        for (int a = 0; a < 5; a++)
        {
            RankScore[a] = PlayerPrefs.GetFloat($"Score{a + 1}");
            Name[a] = PlayerPrefs.GetString($"Name{a + 1}");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        for(int a = 0; a < 5; a++)
        {
            PlayerPrefs.SetFloat($"Score{a + 1}", RankScore[a]);
            PlayerPrefs.SetString($"Name{a + 1}", Name[a]);
            PlayerPrefs.Save();
        }
    }
}
