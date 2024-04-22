using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Key : MonoBehaviour
{
    // Variable Declarations
    public bool playerHasKey = false;
    private bool inTriggerZone = false;
    public TMP_Text text;
    public GameObject dialogueBox;

    // Allows the player to pick up the key with the e key
    // and plays a dialogue box when doing so
    public void Update()
    {
        if (inTriggerZone == true && Input.GetKeyDown(KeyCode.E))
        {
            playerHasKey = true;
            Destroy(gameObject);
            BannerDialogue.hasShown = false;
            dialogueBox.SetActive(true);
        } 
        
    }

    // Reminds the player with a message that they can pick the key with the e key
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            inTriggerZone = true;
            text.text = "PRESS [e] TO PICK UP KEY";
        }
    }

    // Gets rid of the on screen text message
    private void OnTriggerExit2D(Collider2D collision)
    {
        inTriggerZone = false;
        text.text = " ";
    }
}
