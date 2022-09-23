using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftMovement : MonoBehaviour
{
    private float speed = 30;

    // Update is called once per frame
    private void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime * speed);
    }
}
