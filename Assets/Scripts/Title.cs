using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    [SerializeField] private PlayableDirector[] Directors;
    [SerializeField] private GameObject[] Buttons;
    // Start is called before the first frame update
    void Start()
    {
        Directors[0].Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GameStart()
    {
        Directors[0].Stop();
        Directors[1].Play();
        for(int a = 0; a < 4; a++)
        {
            Buttons[a].SetActive(false);
        }
    }
    public void StartScene()
    {
        SceneManager.LoadScene("Stage1");
    }
    public void EndGame()
    {
        Application.Quit();
    }
    public void Ranking()
    {

    }
    public void Setting()
    {

    }
}
