using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Initialize variables
    public GameObject obstaclePrefab;
    private Vector3 spawnPos = new Vector3(35, 0, 0);

    // Start is called before the first frame update
    private void Start()
    {
        // Spawn obstacles every 2 seconds
        InvokeRepeating("SpawnObstacle", 2, 2);
    }

    //  Spawn obstacles
    private void SpawnObstacle()
    {
        Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);
    }
}
