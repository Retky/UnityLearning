using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Controller : PlayerController
{
    protected override void Start()
    {
        base.Start();
        cameraButton = "Camera2";
    }

    protected override void GetInputs()
    {
        // Get inputs
        verticalInput = Input.GetAxis("Vertical2");
        horizontalInput = Input.GetAxis("Horizontal2");
    }
}
