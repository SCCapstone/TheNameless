using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerHealth : MonoBehaviour
{
    public Animator animator;
    public int maxHealth = 1;
    public int currentHealth;
    public Behaviour stopPlayer;
    public RespawnTransition respawn;
    [SerializeField] AudioSource walk;
    [SerializeField] AudioSource hurt;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        animator = GetComponent<Animator>();
        respawn = GameObject.FindGameObjectWithTag("Respawn").GetComponent<RespawnTransition>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;

        if (currentHealth == 0)
        {
            animator.SetBool("isDead", true);
            walk.Pause();
            hurt.Play();
            stopPlayer.enabled = false;
            respawn.InstantiateAnimation();
        }
    }
    
}
