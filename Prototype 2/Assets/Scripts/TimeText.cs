using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timeText;

    // Update is called once per frame
    void Update()
    {
        // Move selft up and banish after 2 seconds
        transform.Translate(Vector3.forward * Time.deltaTime * 2, Space.World);
        Destroy(gameObject, 0.8f);
    }

    // Set text
    public void SetText(string text)
    {
        timeText.text = text;
    }
}
