using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Initialize variables
    private Rigidbody playerRb;
    private GameObject focalPoint;
    public float speed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        // Initialize Variables
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Cam Focal Point");
    }

    // Update is called once per frame
    void Update()
    {
        // Initialize axis variables
        float forwardInput = Input.GetAxis("Vertical");

        // Move the player
        playerRb.AddForce(focalPoint.transform.forward * speed * forwardInput);
    }
}
