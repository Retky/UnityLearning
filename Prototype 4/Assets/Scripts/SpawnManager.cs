using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Initialize reference variables
    public GameObject enemyPrefab;
    private float spawnRange = 9.0f;

    // Start is called before the first frame update
    void Start()
    {
        // Spawn enemy at random position
        Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Generate random spawn position
    private Vector3 GenerateSpawnPosition()
    {
        // Generate random x, y, z position
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosY = 0.1f;
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);

        // Return random position
        return new Vector3(spawnPosX, spawnPosY, spawnPosZ);
    }
}
