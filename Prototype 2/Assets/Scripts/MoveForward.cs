using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    // Speed of the object
    public float speed = 45.0f;
    // Limit the object distance
    public float yRangeMax = 40f;
    public float yRangeMin = -15f;

    // Update is called once per frame
    void Update()
    {
        // Move the object in the forward direction based on the speed in seconds.
        transform.Translate(Vector3.forward * Time.deltaTime * speed);

        if (transform.position.z > yRangeMax || transform.position.z < yRangeMin)
        {
            // Destroy the object if it goes out of bounds
            Destroy(gameObject);
        }
    }
}
