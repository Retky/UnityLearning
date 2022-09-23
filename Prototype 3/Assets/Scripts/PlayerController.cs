using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Initialize variables
    private Rigidbody playerRb;
    private Animator playerAnim;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    private AudioSource playerAudio;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    public float jumpForce = 10;
    public float gravityModifier = 1;
    private bool isOnGround = true;
    public bool gameOver = false;

    // Start is called before the first frame update
    private void Start()
    {
        // Get the rigidbody component
        playerRb = GetComponent<Rigidbody>();
        // Get the animator component
        playerAnim = GetComponent<Animator>();
        // Set the gravity modifier
        Physics.gravity *= gravityModifier;

        // Get the audio source component
        playerAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetButtonDown("Jump") && isOnGround && !gameOver)
        {
            // Jump
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            playerAudio.PlayOneShot(jumpSound, 1.0f);
            isOnGround = false;
            dirtParticle.Stop();
            playerAnim.SetTrigger("Jump_trig");
        }
    }

    // OnCollisionEnter is called when the player collides with an object
    private void OnCollisionEnter(Collision collision)
    {   
        // Check if touch the ground
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            dirtParticle.Play();
        }

        // Check if touch an obstacle
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            playerAudio.PlayOneShot(crashSound, 1.0f);
            explosionParticle.Play();
            dirtParticle.Stop();
            playerAnim.SetBool("Death_b", true);
            gameOver = true;
        }
    }
}
