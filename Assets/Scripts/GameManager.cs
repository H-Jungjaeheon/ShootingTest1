using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; set; }
    public float MaxHp, Hp, Damage, MaxBoom, Boom, Score, Stage, Pain, MaxPain, Shild, MaxShild;
    public bool IsHit, IsShild;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        Health();
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
    }
}
