using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftMovement : MonoBehaviour
{
    private float speed = 28;
    private PlayerController playerControllerScript;

    // Start is called before the first frame update
    private void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    private void Update()
    {   
        // If the game is not over
        if (!playerControllerScript.gameOver)
        {
            // Move the background to the left
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
    }
}
