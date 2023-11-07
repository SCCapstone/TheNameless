using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private float dirX = 0f;
    private SpriteRenderer sprite;
    private bool isOnGround;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        isOnGround = true;
    }

    // Update is called once per frame
    void Update()
    {
        dirX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(dirX * 10f, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && isOnGround == true && rb.gravityScale > 0f)
        {
            rb.velocity = new Vector3(rb.velocity.x, 20f, 0);
            isOnGround= false;
        }
        if (Input.GetButtonDown("Jump") && isOnGround == true && rb.gravityScale < 0f)
        {
            rb.velocity = new Vector3(rb.velocity.x, -20f, 0);
            isOnGround = false;
        }
        if (Input.GetButtonDown("Vertical") && isOnGround == true)
        {
            rb.gravityScale *= -1;
            isOnGround = false;
            FlipUp();
        }

        UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {
        if (dirX > 0f)
        {
            anim.SetBool("running", true);
            sprite.flipX = false;
        }
        else if (dirX < 0f)
        {
            anim.SetBool("running", true);
            sprite.flipX = true;
        }
        else
        {
            anim.SetBool("running", false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isOnGround = true;
        }
    }

    private void FlipUp()
    {
        Vector3 ScalerUP = transform.localScale;
        ScalerUP.y *= -1;
        transform.localScale = ScalerUP;
    }
}
