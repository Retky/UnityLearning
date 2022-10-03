using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    [SerializeField] private float timer = 60.0f;
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private TextMeshProUGUI livesText;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI gameOverText;
    public bool isGameActive = true;

    // Start is called before the first frame update
    void Start()
    {
        // Set the timer text
        timerText.text = "Time: " + timer.ToString("F0");

        // Set the lives text
        livesText.text = "Lives: " + player.GetComponent<PlayerController>().lives.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameActive)
        {
            timer -= Time.deltaTime;
            timerText.text = "Time: " + timer.ToString("0");

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
            Invoke("Restart", 4f);
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
        timer += time;
    }
}
