using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Initialize variables
    private Rigidbody playerRb;
    public float jumpForce = 10;
    public float gravityModifier = 1;

    // Start is called before the first frame update
    void Start()
    {
        // Get the rigidbody component
        playerRb = GetComponent<Rigidbody>();
        // Set the gravity modifier
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}
