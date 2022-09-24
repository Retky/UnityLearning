using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Initialize variables
    public float speed = 10.0f;

    // Update is called once per frame
    void Update()
    {
        // Initialize axis variable
        float horizontalInput = Input.GetAxis("Horizontal");
        // Move the camera left and right
        transform.Rotate(Vector3.up, horizontalInput * speed * Time.deltaTime);
    }
}
