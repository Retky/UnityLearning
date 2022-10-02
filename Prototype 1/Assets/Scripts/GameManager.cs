using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Initialize variables
    public bool isGameActive = false;
    public GameObject titleScreen;
    public Button restartButton;
    public GameObject player1;
    public GameObject player2;

    // Update is called once per frame
    void Update()
    {
        if (player2.activeInHierarchy == false && player1.GetComponent<Rigidbody>().position.y < -3)
        {
            isGameActive = false;
            restartButton.gameObject.SetActive(true);
        } else if (player1.GetComponent<Rigidbody>().position.y < -3 && player2.GetComponent<Rigidbody>().position.y < -3)
        {
            isGameActive = false;
            restartButton.gameObject.SetActive(true);
        }
    }

    public void StartGame()
    {
        // Set the game to active
        isGameActive = true;
        // Hide the title screen
        titleScreen.SetActive(false);
    }

    public void QuitGame()
    {
        // Quit the game
        Application.Quit();
    }

    public void Multiplayer()
    {
        // Enable the second player
        player2.SetActive(true);

        // Change player 1 camera size
        player1.transform.Find("Main Camera1").GetComponent<Camera>().rect = new Rect(0, 0, 0.5f, 1);
        player1.transform.Find("Second Camera1").GetComponent<Camera>().rect = new Rect(0, 0, 0.5f, 1);

        // Move player 1 to the left
        player1.transform.position = new Vector3(-5, 0, 0);
    }

    public void Singleplayer()
    {
        // Enable the second player
        player2.SetActive(false);

        // Change player 1 camera size
        player1.transform.Find("Main Camera1").GetComponent<Camera>().rect = new Rect(0, 0, 1, 1);
        player1.transform.Find("Second Camera1").GetComponent<Camera>().rect = new Rect(0, 0, 1, 1);

        // Move player 1 to the left
        player1.transform.position = new Vector3(0, 0, 0);
    }

    public void RestartGame()
    {
        // Reload the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
