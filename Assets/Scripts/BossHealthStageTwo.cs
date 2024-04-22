using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class BossHealthStageTwo : MonoBehaviour
{
    // Variable Declarations
    public int maxHealth = 15;
    public int currentHealth;
    // Array of boss health
    public Image[] Health;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    public AudioSource hurt;
    public Animator bossAnimator;
    public ExitLevelScriptV2 exitLevel;


    // Start is called before the first frame update
    // Start is called before the first frame update
    // Start is called before the first frame update
    // Sets current health to max health
    // Gets access to exit level script
    void Start()
    {
        exitLevel = GameObject.FindGameObjectWithTag("Exit").GetComponent<ExitLevelScriptV2>();
        currentHealth = 10;
    }

    // Update is called once per frame
    // Keeps track of boss health
    void Update()
    {
        for (int index = 0; index < Health.Length; index++)
        {
            if (index < maxHealth)
            {
                Health[index].enabled = true;
            }
            else
            {
                Health[index].enabled = false;
            }

            if (index < currentHealth)
            {
                Health[index].sprite = fullHeart;
            }
            else
            {
                Health[index].sprite = emptyHeart;
            }
        }
    }

    // Makes the boss take damage
    // plays the hurt sound effect
    // plays boss hurt animation
    // Goes to the next level if boss reaches certain health
    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        hurt.Play();
        bossAnimator.SetBool("isHurt", true);
        StartCoroutine(GoBackToNormalAnimation());

        if (currentHealth <= 5)
        {
            exitLevel.GoToNextLevel();
        }
    }

    // plays boss animations after a certain time
    public IEnumerator GoBackToNormalAnimation()
    {
        yield return new WaitForSeconds(1);
        bossAnimator.SetBool("isHurt", false);
    }

}
