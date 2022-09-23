using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Initialize variables
    public GameObject obstaclePrefab;
    private Vector3 spawnPos = new Vector3(35, 0, 0);
    private PlayerController playerControllerScript;

    // Start is called before the first frame update
    private void Start()
    {
        // Get the PlayerController script
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();

        // Spawn obstacles every 2 seconds
        InvokeRepeating("SpawnObstacle", 2, 2);
    }

    //  Spawn obstacles
    private void SpawnObstacle()
    {
        // If the game is not over
        if (!playerControllerScript.gameOver)
        {
            // Spawn an obstacle
            Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);
        }
    }
}
