using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    public float rotSpeed = 50;

    // Update is called once per frame
    void Update()
    {
        float rotX = Input.GetAxis("Mouse X");

        transform.Rotate(Vector3.up, rotX * 10 * rotSpeed * Time.deltaTime);
    }
}
