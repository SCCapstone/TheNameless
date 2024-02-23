using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorRobotEnemyScript : MonoBehaviour
{
    private float directionX;
    [SerializeField]
    public float moveSpeed = 1f;
    private Rigidbody2D myRigidBody;
    private Vector3 localScale;
    public PlayerHealth playerHealth;
    private SpriteRenderer mySpriteRenderer;
    private bool isOnGround;

    // Start is called before the first frame update
    void Start()
    {
        localScale = transform.localScale;
        myRigidBody = GetComponent<Rigidbody2D>();
        directionX = -1f;
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        isOnGround = true;
    }

    private void FixedUpdate()
    {
        myRigidBody.velocity = new Vector2(directionX * moveSpeed, myRigidBody.velocity.y);        
    }

    void LateUpdate()
    {
        if (directionX > 0)
            FlipX(true);
        else if (directionX < 0)
            FlipX(false);
        
        FlipY();
    }

    public void FlipX(bool isFlipped)
    {
        Vector3 scale = transform.localScale;
        if ((scale.x < 0 && isFlipped) || (scale.x > 0 && !isFlipped))
            scale.x *= -1;
        transform.localScale = scale;
    }

    // Flip Y of the Floor Robot if gravity is reversed
    public void FlipY()
    {
        Vector3 scale = transform.localScale;
        if ((scale.y < 0 && Physics2D.gravity.y < 0) || (scale.y > 0 && Physics2D.gravity.y > 0))
            scale.y *= -1;
        transform.localScale = scale;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
            directionX *= -1f;
        if (collision.gameObject.CompareTag("Player"))
            playerHealth.TakeDamage(1);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
            directionX *= -1f;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            isOnGround = true;
    }

    public Vector2 GetPosition()
    {
        return myRigidBody.position;
    }

    public void EnemyGravityButtonFlip()
    {
        if (isOnGround == true)
        {
            myRigidBody.gravityScale *= -1;
            isOnGround = false;
            if (mySpriteRenderer.flipY == true)
            {
                mySpriteRenderer.flipY = false;
            }
            else
            {
                mySpriteRenderer.flipY = true;
            }
            Vector3 ScalerUP = transform.localScale;
            ScalerUP.y *= -1;
            transform.localScale = ScalerUP;
        }
    }

}
