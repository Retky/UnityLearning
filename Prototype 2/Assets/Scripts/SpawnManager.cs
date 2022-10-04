using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameManager gameManager;
    // Initialize array for locading enemy prefabs
    public GameObject[] animalPrefabs;
    public GameObject player;

    // Initialize variables for spawning
    private float spawnDelay = 0.2f;
    private float[] spawnInterval = {0.3f, 1.8f};
    private float[] aggresiveSpawnInterval = {4.0f, 8.0f};
    private float[] agressiveSpawnSide = {25.0f, -25.0f};

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomAnimal", spawnDelay, Random.Range(spawnInterval[0], spawnInterval[1]));
        InvokeRepeating("SpawnAgressiveAnimal", spawnDelay, Random.Range(aggresiveSpawnInterval[0], aggresiveSpawnInterval[1]));
    }

    // Spawn random animal
    void SpawnRandomAnimal()
    {
        if (gameManager.isGameActive)
        {
            // Set index for ramdom animalPrefabs
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        Vector3 spawnPos = new Vector3(Random.Range(-15, 15), 0, 30);

        // Spawn animal at random location
        Instantiate(animalPrefabs[animalIndex], spawnPos, animalPrefabs[animalIndex].transform.rotation);
        }
    }

    // Spawn aggresive animal
    void SpawnAgressiveAnimal()
    {
        if (gameManager.isGameActive)
        {
            // Set index for ramdom animalPrefabs
            int animalIndex = Random.Range(0, animalPrefabs.Length);
            int side = Random.Range(0, 2);
            Vector3 spawnPos = new Vector3(agressiveSpawnSide[side], 0, Random.Range(2, 25));

            // Spawn animal at random location looking at player
            Instantiate(animalPrefabs[animalIndex], spawnPos, Quaternion.LookRotation(player.transform.position-spawnPos));
        }
    }
}
