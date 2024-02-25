using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ballbehavior : MonoBehaviour
{
    public float minY = -5.5f;
    public float maxV = 10f;
    public float SpeedMultiplyer = 1.5f;
    public int lives = 5;
    public int FailScene;
    public Generator generator;
    Rigidbody2D rb;
    public GameObject[] LivesImage;
    
    void Start()
    {
        generator = FindObjectOfType<Generator>();
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.down * 5f;
    }

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
                rb.velocity = Vector2.down * 5f;
                lives--;
                LivesImage[lives].SetActive(false);
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
            generator.DestroyBrick();
            Destroy(collision.gameObject);
        }
    }

    void GameOver()
    {
        SceneManager.LoadScene(FailScene);
    }

}
