using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserInterface : MonoBehaviour
{
    public GameObject player;
    public Text livesText;
    public Text scoreText;
    public Text gameOverText;

    // Update is called once per frame
    void Update()
    {
        livesText.text = "Lives: " + player.GetComponent<PlayerController>().lives;

        // scoreText.text = "Score: " + player.GetComponent<PlayerController>().score;

        if (player.GetComponent<PlayerController>().lives <= 0)
        {
            gameOverText.text = "Game Over";
        }
    }
}
