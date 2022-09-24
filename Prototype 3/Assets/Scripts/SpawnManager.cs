using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Initialize variables
    public GameObject[] obstaclePrefab;
    private Vector3 spawnPos = new Vector3(35, 0, 0);
    private PlayerController playerControllerScript;

    // Start is called before the first frame update
    private void Start()
    {
        // Get the PlayerController script
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();

        // Spawn obstacles every 2 seconds
        InvokeRepeating("SpawnObstacle", 4, 2);
    }

    //  Spawn obstacles
    private void SpawnObstacle()
    {
        // If the game is not over
        if (!playerControllerScript.gameOver)
        {
            // Generate a random index
            int obstacleIndex = Random.Range(0, obstaclePrefab.Length);

            // Spawn an obstacle
            Instantiate(obstaclePrefab[obstacleIndex], spawnPos, obstaclePrefab[obstacleIndex].transform.rotation);
        }
    }
}
