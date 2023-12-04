using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingRobotEnemyScript : MonoBehaviour
{
    private float directionX;
    public float moveSpeed;
    private Rigidbody2D myRigidBody;
    private bool isFacingRight = false;
    private Vector3 localScale;
    public PlayerHealth playerHealth;

    // Start is called before the first frame update
    void Start()
    {
        localScale = transform.localScale;
        myRigidBody = GetComponent<Rigidbody2D>();
        directionX = -1f;
        moveSpeed = 3f;
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Wall>())
        {
            directionX *= -1f;
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

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerHealth.TakeDamage(1);
        }
    }


}
