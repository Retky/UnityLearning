using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    Vector3 cam;

    // LateUpdate is called once per frame after Update
    void LateUpdate()
    {
        cam = Camera.main.transform.forward;
        transform.LookAt(transform.position + cam);
    }
}
