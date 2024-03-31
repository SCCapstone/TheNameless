using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class BossHealthStageThree : MonoBehaviour
{
    public int maxHealth = 15;
    public int currentHealth;
    public Image[] Health;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    public AudioSource hurt;
    public Animator bossAnimator;
    public ExitLevelScriptV2 exitLevel;


    // Start is called before the first frame update
    void Start()
    {
        exitLevel = GameObject.FindGameObjectWithTag("Exit").GetComponent<ExitLevelScriptV2>();
        currentHealth = 5;
    }

    // Update is called once per frame
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

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        hurt.Play();
        bossAnimator.SetBool("isHurt", true);
        StartCoroutine(GoBackToNormalAnimation());

        if (currentHealth <= 0)
        {
            exitLevel.GoToNextLevel();
        }
    }

    public IEnumerator GoBackToNormalAnimation()
    {
        yield return new WaitForSeconds(1);
        bossAnimator.SetBool("isHurt", false);
    }

}
