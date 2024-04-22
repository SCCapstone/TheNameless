using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KeyLock : MonoBehaviour
{
    // Variable Declarations
    public Key key;
    public ExitLevelScript exit;
    public bool doorIsLocked = true;
    private bool inTriggerZone = false;
    public TMP_Text text;
    public GameObject dialogueBox2;
    public GameObject realKey;

    // Start is called before the first frame update
    // Allows this script to access the Key and Exit scripts.
    void Start()
    {
        key = GameObject.FindGameObjectWithTag("Key").GetComponent<Key>();
        GameObject.FindGameObjectWithTag("Exit").GetComponent<ExitLevelScript>();
    }

    // Update is called once per frame
    // Allows the player to unlock the exit's lock with the key
    // and plays a dialogue box when doing so
    void Update()
    {
        if (inTriggerZone == true && Input.GetKeyDown(KeyCode.E) && key.playerHasKey == true)
        {
            
            doorIsLocked = false;
            BannerDialogue.hasShown = false;
            dialogueBox2.SetActive(true);
            realKey.GetComponent<SpriteRenderer>().enabled = false;
            exit.animator.SetBool("isUnlocked", true);
        }
    }

    // Reminds the player that they can use the key to unlock the lock
    // when pressing the e key
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            inTriggerZone = true;
            text.text = "PRESS [e] TO UNLOCK EXIT DOOR";
        }
    }

    // Gets rid of the text message when player leaves the lock's trigger zone
    private void OnTriggerExit2D(Collider2D collision)
    {
        inTriggerZone = false;
        text.text = " ";
    }
}
