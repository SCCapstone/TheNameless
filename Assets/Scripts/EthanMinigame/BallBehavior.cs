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
    
    // sets ball velocity, grabs a reference to the generator
    void Start()
    {
        generator = FindObjectOfType<Generator>();
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.down * 3f;
    }

    // main game logic, controlls game over, lives lost, and ball respawning
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
                rb.velocity = Vector2.down * 3f;
                lives--;
                LivesImage[lives].SetActive(false);
            }
            
        }
        if(rb.velocity.magnitude > maxV)
        {
            rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxV);
        }
    }
    // destroys "bricks" when ball colides with them
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("brick"))
        {
            generator.DestroyBrick();
            Destroy(collision.gameObject);
        }
    }

    // loads gameover scene if player fails
    void GameOver()
    {
        SceneManager.LoadScene(FailScene);
    }

}
