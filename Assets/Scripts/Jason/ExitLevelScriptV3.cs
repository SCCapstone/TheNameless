using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ExitLevelScriptV3 : MonoBehaviour
{
    // Variable declarations
    public Animator animator;
    private bool inTriggerZone = false;
    public TMP_Text text;
    public Vector2 startGravity;
    public Animator SceneTransition;
    public int sceneToLoad;
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

    // Method that lets the player go on to the next level
    // while the fade transition plays
    public IEnumerator PlayerExitToNextLevel()
    {
        SceneTransition.SetBool("isDead", true);
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(sceneToLoad);
        //Physics2D.gravity = new Vector2(startGravity.x, startGravity.y);
        SceneTransition.SetBool("isDead", false);
    }
}
