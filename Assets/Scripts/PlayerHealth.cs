using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerHealth : MonoBehaviour
{
    // Variable Declarations
    public Animator animator;
    public Animator SceneTransition;
    public PlayerMovement pm;
    public int maxHealth = 1;
    public int currentHealth;
    public Vector2 startGravity;
    public static bool invincibility = false;

    private bool hasPlayed = false;
   
    [SerializeField] AudioSource walk;
    [SerializeField] AudioSource hurt;

    public Rigidbody2D rb;

    // Start is called before the first frame update
    // Starts levels with the right gravity
    // assigns the maxhealth to current health
    // Gets the player's rigidbody
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

    // Allows Player to take damage from robot enemies
    // Stops the player when they die
    // Plays normal death animation
    // Stops the player walk sound effect
    // Plays death sound effect
    public void TakeNormalDamage(int amount)
    {
        if (invincibility == false)
        {
            currentHealth -= amount;
        }

        if (currentHealth <= 0)
        {
            rb.velocity = Vector3.zero;
            pm.enabled = false;
            animator.SetBool("isDead", true);
            walk.Pause();
            if (!hasPlayed)
            {
                hurt.PlayOneShot(hurt.clip);
                hasPlayed = true;
            }
            StartCoroutine(PlayerRespawn());
        }
    }

    // Allows Player to take damage from exposed electrical wires
    // Stops the player when they die
    // Plays electrical death animation
    // Stops the player walk sound effect
    // Plays death sound effect
    public void TakeElectricalDamage(int amount)
    {
        if (invincibility == false)
        {
            currentHealth -= amount;
        }

        if (currentHealth <= 0)
        {
            rb.bodyType = RigidbodyType2D.Static;
            rb.velocity = Vector3.zero;
            pm.enabled = false;
            animator.SetBool("isElectrocuted", true);
            walk.Pause();
            if (!hasPlayed)
            {
                hurt.PlayOneShot(hurt.clip);
                hasPlayed = true;
            }
            StartCoroutine(PlayerRespawn());
        }
    }

    // Allows Player to take damage from lasers
    // Stops the player when they die
    // Plays laser death animation
    // Stops the player walk sound effect
    // Plays death sound effect
    public void TakeLaserDamage(int amount)
    {
        if (invincibility == false)
        {
            currentHealth -= amount;
        }
        if (currentHealth <= 0)
        {
            rb.velocity = Vector3.zero;
            pm.enabled = false;
            animator.SetBool("isDisintegrated", true);
            walk.Pause();
            if (!hasPlayed)
            {
                hurt.PlayOneShot(hurt.clip);
                hasPlayed = true;
            }
            StartCoroutine(PlayerRespawn());
        }
    }


    // Plays the fade transition
    // Reloads the level
    // and Respawns the player
    public IEnumerator PlayerRespawn()
    {
        yield return new WaitForSeconds(1);
        SceneTransition.SetBool("isDead", true);
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        pm.enabled = true;
        Physics2D.gravity = startGravity;
        SceneTransition.SetBool("isDead", false);
    }
    
}
