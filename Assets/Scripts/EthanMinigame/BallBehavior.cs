using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class Ballbehavior : MonoBehaviour
{
    public float minY = -5.5f;
    public float maxV = 15f;
    public float SpeedMultiplyer = 1.5f;
    public float timer = 60f;
    public Generator brickGenerator;
    private Rigidbody2D rb2d;
    Rigidbody2D rb;
    
    void Start()
    {
        InvokeRepeating("DecreaseTimer", 1f, 1f);
        int count = brickGenerator.bc;
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.down * 5f;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < minY)
        {
            transform.position = Vector3.zero;
            rb.velocity = Vector2.down * 5f;
        }
        if(rb.velocity.magnitude > maxV)
        {
            rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxV);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("brick"))
        {
            Destroy(collision.gameObject);
            brickGenerator.DestroyBrick();
            rb2d = collision.gameObject.GetComponent<Rigidbody2D>();
            if (rb2d != null)
            {
                rb2d.velocity *= SpeedMultiplyer;
            }
        }
        if(collision.gameObject.CompareTag("paddle"))
        {
            rb2d = collision.gameObject.GetComponent<Rigidbody2D>();
            if (rb2d != null)
            {
                rb2d.velocity *= SpeedMultiplyer;
            }
        }
    }

    void DecreaseTimer()
    {
        timer -= 1f;
        if (timer <= 0f)
        {
            GameOver();
        }

    }

    void GameOver()
    {
        Debug.Log("GameOver");
    }

}
