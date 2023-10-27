using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
// Kilroy was here
// Ethan
{
    // Variables for movement and direction
    private float horizontal;
    private bool isFacingRight;
    [Header("Movement Parameters")]
    public float speed = 8f;
    public float jumpPower = 16f;

    [Header("Components for movement")]
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private Transform groundCheckReverseGravity;
    [SerializeField] private LayerMask groundLayer;

    private void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        // use if gravity is normal
        if(Input.GetButtonDown("Jump") && IsGrounded() && rb.gravityScale > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
        }

        // if gravity is flipped, jump power is in the negative direction
        if (Input.GetButtonDown("Jump") && IsGrounded() && rb.gravityScale < 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, -jumpPower);
        }

        // if jump button is held, player jumps for longer
        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2 (rb.velocity.x, rb.velocity.y * 0.5f);
        }

        Flip();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal*speed, rb.velocity.y);
    }

    private bool IsGrounded()
    {
        if (rb.gravityScale > 0f)
        {
            return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
        }
        else
        {
            return Physics2D.OverlapCircle(groundCheckReverseGravity.position, 0.2f, groundLayer);
        }
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0 || !isFacingRight && horizontal > 0)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

}
