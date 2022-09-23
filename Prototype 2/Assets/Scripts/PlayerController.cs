using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Player movement
    private float horizontalInput;
    private float verticalInput;
    private float speed = 25.0f;
    public float xRange = 10.0f;
    public float frontRange = 13.0f;
    public float backRange = -1.0f;
    public int lives = 3;

    // Player projectile
    public GameObject projectile;

    // Update is called once per frame
    void Update()
    {
        // End game if player runs out of lives
        if (lives < 1)
        {
            FindObjectOfType<GameManager>().EndGame();
        }

        // Get user input
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        // Prevent the player from going out of bounds
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        else if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }

        if (transform.position.z < backRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, backRange);
        }
        else if (transform.position.z > frontRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, frontRange);
        }

        // Move the player in axis based on the speed in seconds.
        transform.Translate(Vector3.right * Time.deltaTime * horizontalInput * speed);
        transform.Translate(Vector3.forward * Time.deltaTime * verticalInput * speed);


        // Launch a projectile from the player
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(projectile, transform.position, projectile.transform.rotation);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            lives--;
            Debug.Log("Lives: " + lives);
        }
    }
}
