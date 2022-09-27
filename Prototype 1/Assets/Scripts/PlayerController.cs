using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Initialize import variables
    private GameManager gameManager;

    // Initialize variables
    public float speed = 25.0f;
    public float turnSpeed = 30.0f;
    private float horizontalInput;
    private float forwardInput;
    // Cameras
    [SerializeField] private Camera mainCamera;
    [SerializeField] private Camera subCamera;

    // Start is called before the first frame update
    void Start()
    {
        // Get the game manager
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        // Set the main camera to active
        mainCamera.enabled = true;
        subCamera.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        // This get the player inputs
        forwardInput = Input.GetAxis("Vertical1");
        horizontalInput = Input.GetAxis("Horizontal1");

        // Player movement
        if (gameManager.isGameActive)
        {
            // Move the car forward
            transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
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
