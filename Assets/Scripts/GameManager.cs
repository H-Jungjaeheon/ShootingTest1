using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; set; }
    public float MaxHp, Hp, Damage, MaxBoom, Boom, Score, Stage, Pain, MaxPain, ShildTime;
    public bool IsHit, IsShild;
    [SerializeField] private Image HpBar, PainBar;
    [SerializeField] private Text Hptext, PainText,ScoreText;
    [SerializeField] private GameObject[] BoomIcon;

    // Start is called before the first frame update
    void Start()
    {
        //HpBar = GetComponent<Image>();
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        Health();
        Booms();
        ScoreTexts();
        ShildTime -= Time.deltaTime;
    }
    void Health()
    {
        if (Hp >= MaxHp)
        {
            Hp = MaxHp;
        }
        if(Pain <= 0)
        {
            Pain = 0;
        }
        HpBar.fillAmount = Hp / MaxHp;
        PainBar.fillAmount = Pain / MaxPain;
        if(Hp >= 100)
        {
            Hptext.text = $"{MaxHp}\n-----\n{Hp}";
        }
        else if(Hp < 100 && Hp > 0)
        {
            Hptext.text = $"{MaxHp}\n-----\n {Hp}";
        }
        else
        {
            Hptext.text = $"{MaxHp}\n-----\n  {Hp}";
        }
        if (Pain >= 100)
        {
            PainText.text = $"  {Pain}\n-----\n{MaxPain}";
        }
        else if (Pain < 100 && Pain > 0)
        {
            PainText.text = $"  {Pain}\n-----\n{MaxPain}";
        }
        else
        {
            PainText.text = $"  {Pain}\n-----\n{MaxPain}";
        }
    }
    void Booms()
    {
        switch (Boom)
        {
            case 0:
                for (int a = 0; a < 3; a++)
                {
                    BoomIcon[a].SetActive(false);
                }
                break;
            case 1:
                BoomIcon[0].SetActive(true);
                for (int a = 1; a < 3; a++)
                {
                    BoomIcon[a].SetActive(false);
                }
                break;
            case 2:
                BoomIcon[2].SetActive(false);
                for (int a = 2; a < 3; a++)
                {
                    BoomIcon[0].SetActive(true);
                }
                break;
            case 3:
                for (int a = 0; a < 3; a++)
                {
                    BoomIcon[a].SetActive(true);
                }
                break;
        }
    }
    void ScoreTexts()
    {
        ScoreText.text = $"Score : {Score}";
    }
}
