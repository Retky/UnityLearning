using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftMovement : MonoBehaviour
{
    private float speed = 23;
    private PlayerController playerControllerScript;

    // Start is called before the first frame update
    private void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    private void Update()
    {   
        // Move faster if shift is pressed
        if (Input.GetButtonDown("Dash"))
        {
            Debug.Log($"Dash");
            speed = 38;
        }
        else if (Input.GetButtonUp("Dash"))
        {
            speed = 23;
        }

        // If the game is not over
        if (!playerControllerScript.gameOver)
        {
            // Move the background to the left
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
    }
}
