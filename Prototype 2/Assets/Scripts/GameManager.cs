using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool isGameActive = true;

    // EndGame is a public function that can be called from other scripts
    public void EndGame()
    {
        if (isGameActive == true)
        {
            isGameActive = false;

            Invoke("Restart", 4f);
        }
    }

    // Restart the game
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
