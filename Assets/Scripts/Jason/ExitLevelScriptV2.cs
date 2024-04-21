using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ExitLevelScriptV2 : MonoBehaviour
{
    public Animator animator;
    private bool inTriggerZone = false;
    public TMP_Text text;
    public Vector2 startGravity;
    public Animator SceneTransition;
    public GameObject player;
    public PlayerMovement playerMovement;

    private void Start()
    {

    }

    private void Update()
    {
        if (inTriggerZone == true && Input.GetKeyDown(KeyCode.E))
        {
            GameObject playerObject = GameObject.Find("Player");
            player.GetComponent<SpriteRenderer>().enabled = false;
            playerMovement.enabled = false;
            animator.SetBool("isReadyToExit", true);
            StartCoroutine(PlayerExitToNextLevel());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            inTriggerZone = true;
            animator.SetBool("isUnlocked", true);
            text.text = "PRESS [e] TO EXIT";
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        inTriggerZone = false;
        text.text = " ";
    }

    public void GoToNextLevel()
    {
        StartCoroutine(PlayerExitToNextLevel());
    }

    public void ExitLevel()
    {
        GameObject playerObject = GameObject.Find("Player");
        player.GetComponent<SpriteRenderer>().enabled = false;
        playerMovement.enabled = false;
        animator.SetBool("isReadyToExit", true);
        StartCoroutine(PlayerExitToNextLevel());
    }

    public IEnumerator PlayerExitToNextLevel()
    {
        SceneTransition.SetBool("isDead", true);
        yield return new WaitForSeconds(2);
        DoDialogueAndGoToNextLevel.hasShown = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        //Physics2D.gravity = new Vector2(startGravity.x, startGravity.y);
        SceneTransition.SetBool("isDead", false);
    }
}
