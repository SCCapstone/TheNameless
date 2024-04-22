using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ExitLevelScript : MonoBehaviour
{
    // Variable declarations
    public Animator animator;
    private bool inTriggerZone = false;
    public TMP_Text text;
    public KeyLock keyLock;
    public Vector2 startGravity;
    public Animator SceneTransition;
    public GameObject player;
    public PlayerMovement playerMovement;
    public GameObject dialogueBox2;

    // ALlows this script access the keylock script to know if it is unlocked
    private void Start()
    {
        keyLock = GameObject.FindGameObjectWithTag("KeyLock").GetComponent<KeyLock>();
    }

    // Allows the player to press the e key to leave and go on to the next level
    // if the player is in the exit triggerzone and the keylock is unlocked
    private void Update()
    {
        if (inTriggerZone == true && Input.GetKeyDown(KeyCode.E) && keyLock.doorIsLocked == false)
        {
            
            BannerDialogue.hasShown = false;
            dialogueBox2.SetActive(true);
            GameObject playerObject = GameObject.Find("Player");
            player.GetComponent<SpriteRenderer>().enabled = false;
            playerMovement.enabled = false;
            animator.SetBool("isReadyToExit", true);
            StartCoroutine(PlayerExitToNextLevel());
        }
    }

    // Reminds the Player that they can interact with the exit with a message
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            inTriggerZone = true;
            text.text = "PRESS [e] TO EXIT";
        }
    }

    // Gets rid of the message when the player leaves the exit's trigger zone
    private void OnTriggerExit2D(Collider2D collision)
    {
        inTriggerZone = false;
        text.text = " ";
    }

    // Triggers the fade transition and loads the next level
    public IEnumerator PlayerExitToNextLevel()
    {
        SceneTransition.SetBool("isDead", true);
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        //Physics2D.gravity = new Vector2(startGravity.x, startGravity.y);
        SceneTransition.SetBool("isDead", false);
    }
}
