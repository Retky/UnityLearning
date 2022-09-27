using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    private float spawnRate = 1.0f;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI livesText;
    public Button restartButton;
    public GameObject titleScreen;
    public int lives;
    private int score;
    public bool isGameActive;

    public void GameOver()
    {
        isGameActive = false;
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
    }

    IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    public void UpdateLife(int lifeToAdd)
    {
        lives += lifeToAdd;
        livesText.text = "Lives: " + lives;

        if (lives <= 0)
        {
            GameOver();
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame(int dificulty)
    {
        spawnRate /= dificulty;
        titleScreen.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);
        isGameActive = true;
        StartCoroutine(SpawnTarget());
        score = 0;
        scoreText.text = "Score: " + score;
        lives = Mathf.RoundToInt(5/ dificulty);
        livesText.text = "Lives: " + lives;
    }
}
