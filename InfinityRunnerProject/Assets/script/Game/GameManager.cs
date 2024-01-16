using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }
    
    bool gameOver = false;

    [SerializeField] int score = 0;
    [SerializeField] TextMeshProUGUI scoreText;

    ScoreManager scoreManager;
    MainMenu menu;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;

        scoreManager = GameObject.FindObjectOfType<ScoreManager>();
        menu = FindObjectOfType<MainMenu>();
    }

    public void Start()
    {
        scoreText.text = score.ToString();
    }

    public int GetScore()
    {
        return score;
    }



    public void IncrementScore()
    {
        if (!gameOver)
        {
            score++;

            scoreText.text = score.ToString();
            PlayerPrefs.SetInt("scoreMax", score);
        }
    }

    public void SetMaxScore()
    {
        scoreManager.AddScore(new Score(PlayerPrefs.GetString("NameRank"), PlayerPrefs.GetInt("scoreMax")));
        
        menu.AdsLoader();

    }

}
