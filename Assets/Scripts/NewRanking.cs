using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewRanking : MonoBehaviour
{
    public static NewRanking Instance { get; set; }
    public float[] Score = new float[5]{0,0,0,0,0};
    public string[] Name = new string[5];
    [SerializeField] private bool None;
    [SerializeField] private InputField inputs;
    [SerializeField] private GameObject InputObj;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Ranking()
    {
        for(int a = 0; a < 5; a++)
        {
            if(GameManager.Instance.Score >= Score[a])
            {
                Sort(a);
                None = true;
            }
            else
            {
                None = false;
            }
        }
        if(None == false)
        {
            //InputObj.SetActive(false);
            GameManager.Instance.Score = 0;
            End();
        }
    }
    void Sort(int a)
    {
        for(int c = 4; c > a; c--)
        {
            Score[c] = Score[c-1];
            Name[c] = Name[c - 1];
        }
        Score[a] = GameManager.Instance.Score;
        Name[a] = inputs.text;
        inputs.text = "";
        //InputObj.SetActive(false);
        GameManager.Instance.Score = 0;
        End();
    }
    void End()
    {

    }
}
