using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Initialize variables
    private Rigidbody playerRb;
    private GameObject focalPoint;
    public GameObject powerupIndicator;
    public float speed = 5.0f;
    public bool hasPowerup = false;

    // Start is called before the first frame update
    private void Start()
    {
        // Initialize Variables
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Cam Focal Point");
    }

    // Update is called once per frame
    private void Update()
    {
        // Initialize axis variables
        float forwardInput = Input.GetAxis("Vertical");

        // Move the player
        playerRb.AddForce(focalPoint.transform.forward * speed * forwardInput);
        powerupIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            hasPowerup = true;
            Destroy(other.gameObject);
            powerupIndicator.gameObject.SetActive(true);
            StartCoroutine(PowerupCountdownRoutine(7));
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerup)
        {
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position);

            enemyRigidbody.AddForce(awayFromPlayer * 30, ForceMode.Impulse);
        }
    }

    IEnumerator PowerupCountdownRoutine(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        powerupIndicator.gameObject.SetActive(false);
        hasPowerup = false;
    }
}
