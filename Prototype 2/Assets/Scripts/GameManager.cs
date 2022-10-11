using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    [SerializeField] private float gameTime = 30.0f;
    private float timer;
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private TextMeshProUGUI livesText;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI finalScoreText;
    [SerializeField] private GameObject gameOverScreen;
    public bool isGameActive = false;
    public static float score = 0;

    public void StartGame()
    {
        // Set values
        timer = gameTime;
        score = 0;
        player.GetComponent<PlayerController>().lives = 3;

        // Set texts
        timerText.text = "Time: " + timer.ToString("F0");
        livesText.text = "Lives: " + player.GetComponent<PlayerController>().lives.ToString();
        scoreText.text = "Score: " + score.ToString();

        // Set game active
        isGameActive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameActive)
        {
            timer -= Time.deltaTime;
            timerText.text = "Time: " + timer.ToString("0");
            score += Time.deltaTime * 10;
            scoreText.text = "Score: " + Mathf.Round(score).ToString();

            if (timer <= 0)
            {
                EndGame();
            }
        }
    }

    public void UpdateLiveText()
    {
        if (isGameActive)
        {
            livesText.text = "Lives: " + player.GetComponent<PlayerController>().lives.ToString();
        }
    }

    // EndGame is a public function that can be called from other scripts
    public void EndGame()
    {
        if (isGameActive == true)
        {
            gameOverScreen.SetActive(true);
            finalScoreText.text = Mathf.Round(score).ToString();     
            isGameActive = false;
            Invoke("MultiplyScore", 3f);
        }
    }

    // Add time to the timer
    public void AddTime(float time)
    {
        if (isGameActive)
        {
            timer += time;
        }
    }

    // Add points to the score
    public void AddScore(int points)
    {
        if (isGameActive)
        {
            score += points;
            scoreText.text = "Score: " + score.ToString();
        }
    }

    // Multiply the score by lives
    public void MultiplyScore()
    {
        int playerLives = player.GetComponent<PlayerController>().lives;
        for (int i = 0; i < playerLives; i++)
        {
            score *= 2;
            scoreText.text = "Score: " + Mathf.Round(score).ToString();
        }
    }
}
