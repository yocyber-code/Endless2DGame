using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D Rigidbody2D;
    private float jumpForce = 8f;
    private bool isJump = false;
    private Animator animator;
    private AudioSource audioSource;
    public AudioClip jumpSound;

    // Start is called before the first frame update
    void Awake()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("isJumping", isJump);
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) && !isJump)
        {
            audioSource.PlayOneShot(jumpSound);
            PlayerJump();
        }
    }

    private void PlayerJump()
    {
        Rigidbody2D.velocity = Vector2.up * jumpForce;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJump = false;
        }
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameObject.SetActive(false);
            GameManagerController.instance.GameOver();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJump = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            GameManagerController.instance.IncreaseScore();
        }
    }
}
