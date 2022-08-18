using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManagerX : MonoBehaviour
{
    public bool isGameOver;

    private int ballsCaught;
    public TextMeshProUGUI ballsCaughtText;

    private int currentTime;
    public TextMeshProUGUI TimerText;

    public GameObject gameOverTitle;

    void Start()
    {
        StartGame();
    }

    void StartGame()
    {
        isGameOver = false;
        ballsCaught = -1;
        currentTime = 61;

        StartCoroutine(SetTimer());
        UpdateBallsGaught();
    }

    private void Timer()
    {
        currentTime -= 1;
        TimerText.text = "Time: " + currentTime;
        if (currentTime == 0)
        {
            GameOver();
        }
    }

    IEnumerator SetTimer()
    {
        while (!isGameOver)
        {
            yield return new WaitForSeconds(1);
            Timer();
        }
    }

    public void UpdateBallsGaught()
    {
        ballsCaught++;
        ballsCaughtText.text = "Balls caught: " + ballsCaught;
    }

    private void GameOver()
    {
        isGameOver = true;
        gameOverTitle.SetActive(true);
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
