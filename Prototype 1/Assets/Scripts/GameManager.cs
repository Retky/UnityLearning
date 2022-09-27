using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Initialize variables
    public bool isGameActive = false;
    public GameObject titleScreen;
    public GameObject gameOverScreen;

    public void StartGame()
    {
        // Set the game to active
        isGameActive = true;
        // Hide the title screen
        titleScreen.SetActive(false);
    }
}
