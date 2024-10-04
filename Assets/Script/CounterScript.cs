using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CounterScript : MonoBehaviour
{
    public int Score;
    public float speed;
    public Text scoreText;
    public int timer = 0;
    public bool GameIsOver = false;
    public GameObject GameOverScreen;

    private void Start()
    {
        GameIsOver = false;
        Score = 0;
        scoreText.text = Score.ToString();
    }
    public void addScore()
    {
        Score += 1;
        scoreText.text = Score.ToString();
    }
    public void addScore(int BonusScore) {
        Score += BonusScore;
        scoreText.text = Score.ToString();
    }
    public void timeCounter()
    {
        timer += 1;
    }

    public void speedCounter()
    {
        speed += 0.1f;
    }
    public void GameOver () 
    {
        GameIsOver = true;
        GameOverScreen.SetActive(true);


    }
    public void TryAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        GameOverScreen.SetActive(false);  
        GameIsOver =false;

    }
}
