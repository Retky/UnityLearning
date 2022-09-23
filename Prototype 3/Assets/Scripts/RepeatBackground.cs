using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    // Initialize variables
    private Vector3 startPos;
    private float repeatWidth;

    // Start is called before the first frame update
    private void Start()
    {
        // Get the starting position of the background
        startPos = transform.position;
        // Get the width of the background
        repeatWidth = GetComponent<BoxCollider2D>().size.x / 2;
    }

    // Update is called once per frame
    private void Update()
    {
        // If the background has moved past the starting position
        if (transform.position.x < startPos.x - repeatWidth)
        {
            // Move the background back to the starting position
            transform.position = startPos;
        }
    }
}
