using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    // Initialize import variables
    private GameManager gameManager;
    private Rigidbody playerRb;
    [SerializeField] private GameObject[] frontWheels;
    [SerializeField] private GameObject[] rearWheels;
    protected float verticalInput;
    protected float horizontalInput;

    // Intialize variables
    [SerializeField] private float horsePower = 1500;
    // [SerializeField] private float breakPower = 1000;
    [SerializeField] private float maxSteerAngle = 30;
    private float currentAcceleration = 0;
    private float currentSteerAngle = 0;
    
    // Initialize wheel colliders
    private WheelCollider WheelColliderFront1;
    private WheelCollider WheelColliderFront2;
    private WheelCollider WheelColliderRear1;
    private WheelCollider WheelColliderRear2;

    // Cameras
    [SerializeField] private Camera mainCamera;
    [SerializeField] private Camera subCamera;
    protected string cameraButton;

    // UI elements
    [SerializeField] private float speedometer;
    [SerializeField] private float rpmIndicator;
    [SerializeField] private TextMeshProUGUI speedometerText;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        cameraButton = "Camera1";

        // Get the game manager
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        // Get the player rigidbody
        playerRb = GetComponent<Rigidbody>();

        // Initialize wheel colliders
        WheelColliderFront1 = frontWheels[0].GetComponent<WheelCollider>();
        WheelColliderFront2 = frontWheels[1].GetComponent<WheelCollider>();
        WheelColliderRear1 = rearWheels[0].GetComponent<WheelCollider>();
        WheelColliderRear2 = rearWheels[1].GetComponent<WheelCollider>();

        // Set the main camera to active
        mainCamera.enabled = true;
        subCamera.enabled = false;
    }

    // Update is called once per frame
    private void Update()
    {
        GetInputs();

        // Update current values
        currentAcceleration = verticalInput * horsePower;
        currentSteerAngle = horizontalInput * maxSteerAngle;

        // Update wheel positions
        frontWheels[0].transform.localRotation = Quaternion.Euler(0, currentSteerAngle, 0);
        frontWheels[1].transform.localRotation = Quaternion.Euler(0, currentSteerAngle, 0);

        // Switch cameras
        if (Input.GetButtonDown(cameraButton))
        {
            mainCamera.enabled = !mainCamera.enabled;
            subCamera.enabled = !subCamera.enabled;
        }
    }

    // FixedUpdate is called once per frame at a fixed time interval (physics)
    private void FixedUpdate()
    {
        // Player movement
        if (gameManager.isGameActive)
        {
            // Update wheel colliders
            WheelColliderFront1.steerAngle = currentSteerAngle;
            WheelColliderFront2.steerAngle = currentSteerAngle;
            WheelColliderRear1.motorTorque = currentAcceleration;
            WheelColliderRear2.motorTorque = currentAcceleration;
        }
    }

    // LateUpdate is called once per frame after all other updates have been completed
    private void LateUpdate()
    {
        // Update UI elements
        speedometer = playerRb.velocity.magnitude * 3.6f;
        rpmIndicator = (currentAcceleration / horsePower) * 1000;
        speedometerText.text = "Speed: " + Mathf.Round(speedometer) + " km/h";
    }

    // Set the user inputs
    protected virtual void GetInputs()
    {
        // Get user inputs
        verticalInput = Input.GetAxis("Vertical1");
        horizontalInput = Input.GetAxis("Horizontal1");
    }
}
