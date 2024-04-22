using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ExitLevelScriptV2 : MonoBehaviour
{
    // Variable declarations
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

    // Allows the player to press the e key to leave and go on to the next level
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

    // Reminds the Player that they can interact with the exit with a message
    // and plays the exit doors opening animation
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            inTriggerZone = true;
            animator.SetBool("isUnlocked", true);
            text.text = "PRESS [e] TO EXIT";
        }
    }

    // Gets rid of the message when the player leaves the exit's trigger zone
    private void OnTriggerExit2D(Collider2D collision)
    {
        inTriggerZone = false;
        text.text = " ";
    }

    // Method that allows the player to go on to the next level
    // without disable the player for the cheat code
    public void GoToNextLevel()
    {
        StartCoroutine(PlayerExitToNextLevel());
    }

    // Method that disables the player so that the exit animation can play
    public void ExitLevel()
    {
        GameObject playerObject = GameObject.Find("Player");
        player.GetComponent<SpriteRenderer>().enabled = false;
        playerMovement.enabled = false;
        animator.SetBool("isReadyToExit", true);
        StartCoroutine(PlayerExitToNextLevel());
    }

    // Method that lets the player go on to the next level
    // while the fade transition plays
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
