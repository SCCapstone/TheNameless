using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer sprite;
    public bool isOnGround;
    private bool isRunning = false;
    private bool horizGravity;
    private Vector3 localScale;
    [SerializeField] float jumpPower = 10f;
    [SerializeField] float runSpeedMultiplier = 2f;
    [SerializeField] float walkSpeed = 5f;
    [SerializeField] AudioSource jump;
    [SerializeField] AudioSource walk;
    [SerializeField] AudioSource reverseGrav;
    [SerializeField] bool hasGravityController = true;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        localScale = transform.localScale;
        isOnGround = true;
        walk.Play();
        walk.Pause();
    }

    // Update is called once per frame
    void Update()
    {
        horizGravity = Physics2D.gravity.y == 0f;

        isRunning = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);

        Move(Input.GetAxis(horizGravity ? "Vertical" : "Horizontal"), isRunning);

        if (Input.GetButtonDown("Jump") && isOnGround == true)
            Jump(jumpPower);
        else if (Input.GetButtonDown(horizGravity ? "Horizontal" : "Vertical") && isOnGround == true && hasGravityController)
            ReverseGravity();

        // if you're not touching the ground, the player sprite should be jumping 
        animator.SetBool("isJumping", !isOnGround);

        // This flips the player depending on gravity direction
        FlipY();

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            isOnGround = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            isOnGround = false;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            isOnGround = true;
    }

    // Be sure to set your Player GameObject to flipX=True and X scale to -1 to start
    public void FlipX(bool isFlipped)
    {
        Vector3 scale = transform.localScale;
        if ((scale.x < 0 && isFlipped) || (scale.x > 0 && !isFlipped))
            scale.x *= -1;
        transform.localScale = scale;
    }

    // Flip Y of the Player if gravity is reversed
    private void FlipY()
    {
        Vector3 scale = transform.localScale;
        if (horizGravity)
        {
            if ((scale.y > 0 && Physics2D.gravity.x < 0) || (scale.y < 0 && Physics2D.gravity.x > 0))
                scale.y *= -1;
            transform.localRotation = Quaternion.Euler(0, 0, 90);
        }
        else
        {
            if ((scale.y < 0 && Physics2D.gravity.y < 0) || (scale.y > 0 && Physics2D.gravity.y > 0))
                scale.y *= -1;
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        transform.localScale = scale;
    }

    // Handle's the player's left and right movement
    public void Move(float dirX, bool isRunning) {
        float speed = isRunning ? walkSpeed * runSpeedMultiplier : walkSpeed;

        if (horizGravity)
            rb.velocity = new Vector2(rb.velocity.x, dirX * speed);
        else
            rb.velocity = new Vector2(dirX * speed, rb.velocity.y);

        // if the player is moving left or right, start the running animation
        animator.SetBool("isRunning", dirX != 0);

        if (dirX > 0f)
        {
            FlipX(false);
            if (walk != null && !walk.isPlaying)
                walk.UnPause();
        }
        else if (dirX < 0f)
        {
            FlipX(true);
            if (walk != null && !walk.isPlaying)
                walk.UnPause();
        }
        else
        {
            if (walk != null)
                walk.Pause();
        }
    }

    public void Jump(float power)
    {
        jump.Play();
        if (horizGravity)
            rb.velocity = new Vector2(-GetSign(Physics2D.gravity.x) * power, rb.velocity.y);
        else
            rb.velocity = new Vector2(rb.velocity.x, -GetSign(Physics2D.gravity.y) * power);
    }

    public void ReverseGravity()
    {
        reverseGrav.Play();
        // Reverse global gravity (for player and objects)
        if (horizGravity)
            Physics2D.gravity = new Vector2(-Physics2D.gravity.x, Physics2D.gravity.y);
        else
            Physics2D.gravity = new Vector2(Physics2D.gravity.x, -Physics2D.gravity.y);
    }

    public void RotateGravity()
    {
        reverseGrav.Play();
        Physics2D.gravity = new Vector2(-Physics2D.gravity.y, Physics2D.gravity.x);
    }

    public Vector2 GetPosition() {
        return rb.position;
    }

    public int GetSign(float val)
    {
        return val != 0f ? (int)(val / Math.Abs(val)) : 0;
    }

}
