using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    [SerializeField] private float timer = 30.0f;
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private TextMeshProUGUI livesText;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI gameOverText;
    public bool isGameActive = true;
    public float score = 0;

    // Start is called before the first frame update
    void Start()
    {
        // Set the timer text
        timerText.text = "Time: " + timer.ToString("F0");

        // Set the lives text
        livesText.text = "Lives: " + player.GetComponent<PlayerController>().lives.ToString();

        // Set the score text
        scoreText.text = "Score: " + score.ToString();
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
            gameOverText.gameObject.SetActive(true);
            isGameActive = false;
            Invoke("MultiplyScore", 3f);

            Invoke("Restart", 5f);
        }
    }

    // Restart the game
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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
