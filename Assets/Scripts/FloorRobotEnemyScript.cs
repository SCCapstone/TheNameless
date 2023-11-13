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

    // Start is called before the first frame update
    void Start()
    {
        localScale = transform.localScale;
        myRigidBody = GetComponent<Rigidbody2D>();
        directionX = -1f;
        moveSpeed = 3f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<Wall>())
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
}
