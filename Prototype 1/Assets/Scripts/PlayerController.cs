using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Initialize import variables
    private GameManager gameManager;
    private Rigidbody playerRb;
    private float horizontalInput;
    private float forwardInput;
    [SerializeField] GameObject centerOfMass;

    // Initialize variables
    [SerializeField] private float horsePower = 0;
    [SerializeField] private float turnSpeed = 30.0f;
    // Cameras
    [SerializeField] private Camera mainCamera;
    [SerializeField] private Camera subCamera;

    // Start is called before the first frame update
    void Start()
    {
        // Get the game manager
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        // Get the player rigidbody
        playerRb = GetComponent<Rigidbody>();
        playerRb.centerOfMass = centerOfMass.transform.localPosition;
        // Set the main camera to active
        mainCamera.enabled = true;
        subCamera.enabled = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // This get the player inputs
        forwardInput = Input.GetAxis("Vertical1");
        horizontalInput = Input.GetAxis("Horizontal1");

        // Player movement
        if (gameManager.isGameActive)
        {
            // Move the car forward
            playerRb.AddRelativeForce(Vector3.forward * forwardInput * (horsePower * 10));
            // Turn the car
            transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);
        }

        // Switch cameras
        if (Input.GetButtonDown("Camera1"))
        {
            mainCamera.enabled = !mainCamera.enabled;
            subCamera.enabled = !subCamera.enabled;
        }
    }
}
