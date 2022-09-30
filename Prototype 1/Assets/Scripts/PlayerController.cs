using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Initialize import variables
    private GameManager gameManager;
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

    // Start is called before the first frame update
    protected virtual void Start()
    {
        cameraButton = "Camera1";

        // Get the game manager
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

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

    // Set the user inputs
    protected virtual void GetInputs()
    {
        // Get user inputs
        verticalInput = Input.GetAxis("Vertical1");
        horizontalInput = Input.GetAxis("Horizontal1");
    }
}
