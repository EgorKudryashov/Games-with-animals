using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool isGameOver;

    private int score;
    public TextMeshProUGUI scoreText;
    private int addLivesForScore;

    private int lives;
    public TextMeshProUGUI livesText;

    public GameObject restartTitle;

    void Start()
    {
        StartGame();
    }

    void StartGame() { 
        isGameOver = false;
        score = 0;
        lives = 3;
        addLivesForScore = 50;

        UpdateScore(0);
        UpdateLives(0);
    }

    public void UpdateScore(int addScore)
    {
        score += addScore;
        scoreText.text = "Score: " + score;
        if (score >= addLivesForScore)
        {
            UpdateLives(1);
            addLivesForScore += addLivesForScore;
        }
    }

    public void UpdateLives(int addLives)
    {
        lives += addLives;
        if (lives > 0)
        {
            livesText.text = "Lives: " + lives;
        }
        if (lives == 0)
        {
            livesText.text = "Lives: 0";
            GameOver();
        }
    }

    private void GameOver()
    {
        isGameOver = true;
        restartTitle.SetActive(true);
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
