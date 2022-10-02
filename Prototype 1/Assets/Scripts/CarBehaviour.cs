using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarBehaviour : MonoBehaviour
{
    // Initialize import variables
    private GameManager gameManager;

    // Initialize variables
    [SerializeField] private float speed = 20.0f;

    // Start is called before the first frame update
    void Start()
    {
        // Get the game manager
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // If the game is active
        if (gameManager.isGameActive)
        {
            // Move the car forward
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }
    }
}
