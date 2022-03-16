using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Scenemanager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GoStageOne()
    {
        SceneManager.LoadScene("Stage1");
    }
    public void GameQuit()
    {
        Application.Quit();
    }
    public void GoRanking()
    {

    }
    public void HowToPlay()
    {

    }
}
