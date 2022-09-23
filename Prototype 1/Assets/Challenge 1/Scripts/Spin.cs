using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    public float rotationSpeed = 3.0f;

    // Update is called once per frame
    void Update()
    {
        // rotate the propeller at a constant speed
        transform.Rotate(Vector3.forward * rotationSpeed);
    }
}
