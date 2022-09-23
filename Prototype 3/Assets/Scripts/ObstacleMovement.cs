using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    private float speed = 10;

    // Update is called once per frame
    private void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime * speed);

        // Destroy obstacles when they leave the screen
        if (transform.position.x < -9)
        {
            Destroy(gameObject);
        }
    }
}
