using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemyStageThree : MonoBehaviour
{
    // Variable Declarations
    private float directionX;
    public float moveSpeed;
    private Rigidbody2D myRigidBody;
    private bool isFacingRight = false;
    private Vector3 localScale;
    public PlayerHealth playerHealth;
    public BossHealthStageThree bossHealth;

    // Start is called before the first frame update
    // Gets access to player's health script
    // Gets access to the boss' health script
    // Sets the boss' direction when starting level
    // Gets the boss' rigidbody
    void Start()
    {
        localScale = transform.localScale;
        myRigidBody = GetComponent<Rigidbody2D>();
        directionX = -1f;
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        bossHealth = GameObject.FindGameObjectWithTag("Enemy").GetComponent<BossHealthStageThree>();
    }

    // Allows the boss to take damage from metal crates
    // Hurts the player if the boss and the player touch
    // Changes the boss' direction when they touch a wall
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
        else if (collision.gameObject.name.Equals("MovableMetalCrate"))
        {
            bossHealth.TakeDamage(1);
        }
    }

    // actually moves the boss
    private void FixedUpdate()
    {
        myRigidBody.velocity = new Vector2(directionX * moveSpeed, myRigidBody.velocity.y);
    }

    // Flips the boss sprite when they switch directions
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

    // Flips the enemy sprite when gravity is changed
    public void FlipY()
    {
        Vector3 scale = transform.localScale;
        if ((scale.y < 0 && Physics2D.gravity.y < 0) || (scale.y > 0 && Physics2D.gravity.y > 0))
            scale.y *= -1;
        transform.localScale = scale;
    }

}
