using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorRobotEnemyScript : MonoBehaviour
{
    // Variable Declarations
    private float directionX;
    [SerializeField]
    public float moveSpeed = 1f;
    private Rigidbody2D myRigidBody;
    private Vector3 localScale;
    public PlayerHealth playerHealth;
    private SpriteRenderer mySpriteRenderer;
    private bool isOnGround;

    // Start is called before the first frame update
    // Gets access to player health script
    // Gets access to player's rigidbody
    // sets enemy direction when starting level
    void Start()
    {
        localScale = transform.localScale;
        myRigidBody = GetComponent<Rigidbody2D>();
        directionX = -1f;
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        isOnGround = true;
    }

    // Actually makes the enemy moves
    private void FixedUpdate()
    {
        myRigidBody.velocity = new Vector2(directionX * moveSpeed, myRigidBody.velocity.y);        
    }

    // Flips the enemy sprite when they switch directions
    void LateUpdate()
    {
        if (directionX > 0)
            FlipX(true);
        else if (directionX < 0)
            FlipX(false);
        
        FlipY();
    }

    // Actually flips the enemy sprite
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

    // Makes the player take damage when it touches player
    // Make the robot enemy switch directions when it touches a wall
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
            directionX *= -1f;
        if (collision.gameObject.CompareTag("Player"))
            playerHealth.TakeNormalDamage(1);
    }

    // Switches enemy's direction when its touches a wall
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
            directionX *= -1f;
    }

    // When the enemy touches the ground, assign isOnGround variable to true
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            isOnGround = true;
    }

    // Gets the enemy's position
    public Vector2 GetPosition()
    {
        return myRigidBody.position;
    }

    // Flips the enemy sprite when gravity is changed
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
