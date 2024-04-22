using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingRobotEnemyScript : MonoBehaviour
{
    // Variable Declarations
    private float directionX;
    public float moveSpeed;
    private Rigidbody2D myRigidBody;
    private bool isFacingRight = false;
    private Vector3 localScale;
    public PlayerHealth playerHealth;

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

    }

    // Makes the player take damage when it touches player
    // Make the robot enemy switch directions when it touches a wall
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Wall"))
        {
            directionX *= -1f;
        }
        else if (collision.gameObject.name.Equals("Player"))
        {
            playerHealth.TakeNormalDamage(1);
        }
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

        FlipY();
    }

    // Flips the enemy sprite when gravity is switched
    public void FlipY()
    {
        Vector3 scale = transform.localScale;
        if ((scale.y < 0 && Physics2D.gravity.y < 0) || (scale.y > 0 && Physics2D.gravity.y > 0))
            scale.y *= -1;
        transform.localScale = scale;
    }

}
