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
   
    [SerializeField] AudioSource walk;
    [SerializeField] AudioSource hurt;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
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
            StartCoroutine(PlayerRespawn());
        }
    }

    public IEnumerator PlayerRespawn()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
}
