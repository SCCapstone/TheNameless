using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemyStageOne : MonoBehaviour
{
    private float directionX;
    public float moveSpeed;
    private Rigidbody2D myRigidBody;
    private bool isFacingRight = false;
    private Vector3 localScale;
    public PlayerHealth playerHealth;
    public BossHealthStageOne bossHealth;

    // Start is called before the first frame update
    void Start()
    {
        localScale = transform.localScale;
        myRigidBody = GetComponent<Rigidbody2D>();
        directionX = -1f;
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        bossHealth = GameObject.FindGameObjectWithTag("Enemy").GetComponent<BossHealthStageOne>();
    }

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

        FlipY();
    }
    public void FlipY()
    {
        Vector3 scale = transform.localScale;
        if ((scale.y < 0 && Physics2D.gravity.y < 0) || (scale.y > 0 && Physics2D.gravity.y > 0))
            scale.y *= -1;
        transform.localScale = scale;
    }

}