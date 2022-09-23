using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Controller : MonoBehaviour
{
    // Cameras
    public Camera mainCamera;
    public Camera subCamera;

    public float speed = 25.0f;
    public float turnSpeed = 30.0f;
    private float horizontalInput;
    private float forwardInput;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera.enabled = true;
        subCamera.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        // This is where we get player input
        forwardInput = Input.GetAxis("Vertical2");
        horizontalInput = Input.GetAxis("Horizontal2");
        // Move the vehicle forward
        transform.Translate(Vector3.forward * Time.deltaTime * forwardInput * speed);
        // Turn the vehicle left and right
        transform.Rotate(Vector3.up, Time.deltaTime * horizontalInput * turnSpeed);

        // Switch cameras
        if (Input.GetButtonDown("Camera2"))
        {
            mainCamera.enabled = !mainCamera.enabled;
            subCamera.enabled = !subCamera.enabled;
        }
    }
}
