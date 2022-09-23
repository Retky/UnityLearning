using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutside : MonoBehaviour
{
    // Update is called once per frame
    private void Update()
    {
        // Destroy obstacles when they leave the screen
        if (transform.position.x < -9)
        {
            Destroy(gameObject);
        }
    }
}
