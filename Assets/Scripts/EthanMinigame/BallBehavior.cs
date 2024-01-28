using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float minY = -5.5f;
    public float maxV = 15f;
    public int lives = 5;

    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.down * 10f;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < minY)
        {
            if (lives <= 0)
            {
                GameOver();
            }
            else
            {
                transform.position = Vector3.zero;
                rb.velocity = Vector2.down * 10f;
                lives--;
            }
            
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
        }
    }

    void GameOver()
    {
        Debug.Log("GameOver");
    }
}
