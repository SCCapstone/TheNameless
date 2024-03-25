using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerHealth : MonoBehaviour
{
    public Animator animator;
    public Animator SceneTransition;
    public int maxHealth = 1;
    public int currentHealth;
    public Vector2 startGravity;
    public static bool invincibility = false;
   
    [SerializeField] AudioSource walk;
    [SerializeField] AudioSource hurt;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        startGravity = Physics2D.gravity;
        currentHealth = maxHealth;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeDamage(int amount)
    {
        if (invincibility == false)
        {
            currentHealth -= amount;
        }
        if (currentHealth <= 0)
        {
            rb.bodyType = RigidbodyType2D.Static;
            animator.SetBool("isDead", true);
            walk.Pause();
            hurt.Play();
            StartCoroutine(PlayerRespawn());
        }
    }

    public IEnumerator PlayerRespawn()
    {
        SceneTransition.SetBool("isDead", true);
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Physics2D.gravity = new Vector2(startGravity.x, startGravity.y);
        SceneTransition.SetBool("isDead", false);
        rb.bodyType = RigidbodyType2D.Static;
    }
    
}
