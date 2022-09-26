using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    // Initialize variables
    private Rigidbody enemyRb;
    public float speed = 5.0f;
    // Initialize Reference Variables
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        // Initialize Variables
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        // Move the enemy towards the player
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        enemyRb.AddForce(lookDirection * speed);

        // If the enemy falls off the map, destroy it
        if (transform.position.y < -2.5)
        {
            Destroy(gameObject);
        }
    }
}
