using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody playerRb;
    Animator playerAnimator;

    [SerializeField]ParticleSystem explosionParticle;
    [SerializeField] ParticleSystem dirtparticle;

    [SerializeField] float jumpForce;
    [SerializeField] float gravityModifier;

    public bool gameOver;

    bool isOnGround = true;

    // Start is called before the first frame update
    void Start()
    {
        Physics.gravity *= gravityModifier;

        playerRb = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            playerAnimator.SetTrigger("Jump_trig");
            dirtparticle.Stop();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            dirtparticle.Play();
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("GAME OVER");
            gameOver = true;
            playerAnimator.SetBool("Death_b", true);
            playerAnimator.SetInteger("DeathType_int", 1);
            dirtparticle.Stop();
            explosionParticle.Play();
        }
    }
}
