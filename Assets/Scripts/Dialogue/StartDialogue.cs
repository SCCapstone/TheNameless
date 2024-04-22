using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartDialogue : MonoBehaviour
{
    [SerializeField] GameObject dialogueBox;

    // on player entering a trigger box, enable dialogue and disable trigger to avoid retriggering the dialogue
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) { 
            BannerDialogue.hasShown = false;
            dialogueBox.SetActive(true);
            gameObject.SetActive(false);
        }
        gameObject.SetActive(false);
    }

    

}
