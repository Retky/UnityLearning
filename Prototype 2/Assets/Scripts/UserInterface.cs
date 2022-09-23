using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserInterface : MonoBehaviour
{
    public GameObject player;
    public Text livesText;

    // Update is called once per frame
    void Update()
    {
        livesText.text = "Lives: " + player.GetComponent<PlayerController>().lives;
    }
}
