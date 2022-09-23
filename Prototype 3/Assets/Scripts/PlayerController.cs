using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Initialize variables
    private Rigidbody playerRb;
    public float jumpForce = 10;
    public float gravityModifier = 1;
    private bool isOnGround = true;
    public bool gameOver = false;

    // Start is called before the first frame update
    private void Start()
    {
        // Get the rigidbody component
        playerRb = GetComponent<Rigidbody>();
        // Set the gravity modifier
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetButtonDown("Jump") && isOnGround)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
        }
    }

    // OnCollisionEnter is called when the player collides with an object
    private void OnCollisionEnter(Collision collision)
    {   
        // Check if touch the ground
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }

        // Check if touch an obstacle
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
        }
    }
}
