using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Initialize reference variables
    public GameObject enemyPrefab;
    public GameObject powerupPrefab;
    private float spawnRange = 9.0f;
    private int enemyCount;
    private int waveSize = 1;

    // Start is called before the first frame update
    void Start()
    {
        EnemyWaves(1);
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<EnemyBehavior>().Length;
        if (enemyCount == 0)
        {
            waveSize += 1;
            EnemyWaves(waveSize);
        }
    }

    // Generate waves of enemies
    void EnemyWaves(int waves)
    {
        for (int i = 0; i < waves; i += 1)
        {
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
            Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
        }
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
