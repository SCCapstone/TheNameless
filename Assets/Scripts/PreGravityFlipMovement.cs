using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PreGravityFlipMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer sprite;
    private bool isOnGround;
    private bool isRunning = false;
    [SerializeField] float jumpPower = 10f;
    [SerializeField] float runSpeedMultiplier = 2f;
    [SerializeField] float walkSpeed = 5f;
    [SerializeField] AudioSource jump;
    [SerializeField] AudioSource walk;
    [SerializeField] AudioSource reverseGrav;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        isOnGround = true;
        walk.Play();
        walk.Pause();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        isRunning = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);
        Move(horizontalInput, isRunning);

        if (Input.GetButtonDown("Jump") && isOnGround == true)
        {
            jump.Play();
            rb.velocity = new Vector3(rb.velocity.x, rb.gravityScale * jumpPower, 0);
            isOnGround = false;
            animator.SetBool("isJumping", true);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            animator.SetBool("isJumping", false);
        }
    }


    public void Move(float dirX, bool isRunning)
    {
        float speed = isRunning ? walkSpeed * runSpeedMultiplier : walkSpeed;
        rb.velocity = new Vector2(dirX * speed, rb.velocity.y);

        if (walk != null && !walk.isPlaying)
        {
            walk.UnPause();
            animator.SetBool("isRunning", true);
        }
        else if (walk != null)
        {
            walk.Pause();
            animator.SetBool("isRunning", false);
        }
  
    }

    public Vector2 GetPosition()
    {
        return rb.position;
    }
}
