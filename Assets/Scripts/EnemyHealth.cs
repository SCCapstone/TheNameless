using System.Collections;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    private int currentHealth;
    public Animator animator;
    public AudioSource hurt;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    void TakeDamage()
    {
        animator.SetBool("isHurt", true);
        currentHealth--;
        hurt.Play();
        StartCoroutine(GoBackToNormalAnimation());
    }

    public IEnumerator GoBackToNormalAnimation()
    {
        yield return new WaitForSeconds(0.5f);
        animator.SetBool("isHurt", false);
        
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.name.Equals("Crusher"))
        {
            TakeDamage();
        }
    }
}
