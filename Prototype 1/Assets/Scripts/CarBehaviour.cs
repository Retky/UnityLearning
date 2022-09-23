using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarBehaviour : MonoBehaviour
{
    private float speed = 15.0f;

    // Update is called once per frame
    void Update()
    {
        // move the car forward at a constant rate
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
