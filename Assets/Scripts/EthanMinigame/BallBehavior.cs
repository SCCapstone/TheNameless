using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float minY = -5.5f;
    public float maxV = 15f;
    public float SpeedMultiplyer = 1.5f;
    public float LevelTime = 60f;
    private Rigidbody2D rb2d;

    Rigidbody2D rb;
    // Start is called before the first frame update
    public float timer;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.down * 5f;
        timer = LevelTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer <= 0)
        {
            GameOver();
        }
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

    void GameOver()
    {
        Debug.Log("GameOver");
    }
}
