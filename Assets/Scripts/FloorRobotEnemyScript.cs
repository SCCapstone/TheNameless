using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorRobotEnemyScript : MonoBehaviour
{
    private float directionX;
    public float moveSpeed;
    private Rigidbody2D myRigidBody;
    private bool isFacingRight = false;
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
        moveSpeed = 1f;
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        isOnGround = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<Wall>())
        {
            directionX *= -1f;
        }
        if (collision.gameObject.name.Equals("Player"))
        {
            playerHealth.TakeDamage(1);
        }
    }

    private void FixedUpdate()
    {
        myRigidBody.velocity = new Vector2(directionX * moveSpeed, myRigidBody.velocity.y);        
    }

    void LateUpdate()
    {
        if (directionX > 0)
        {
            isFacingRight = true;
        }
        else if (directionX < 0)
        {
            isFacingRight = false;
        }

        if (((isFacingRight) && (localScale.x < 0)) || ((!isFacingRight) && (localScale.x > 0)))
        {
            localScale.x *= -1;
        }

        transform.localScale = localScale;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isOnGround = true;
        }
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
