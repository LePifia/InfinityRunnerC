using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public static MainMenu instance { get; private set; }
    [SerializeField] float timer = 0;
    bool timerDone = false;


    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }

    private void Update()
    {
        if (timerDone == true)
        {
            timer += Time.deltaTime;

            if (timer > 2)
            {
                HighScores();
            }
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene("MainGame");
    }

    public void MainMenuLoader()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void HighScoresLoader()
    {
        timerDone = true;
    }

    public void AdsLoader()
    {


        SceneManager.LoadScene("Comercials");

    }
    public void HighScores()
    {

   
            SceneManager.LoadScene("HighScores");
        
    }
}
