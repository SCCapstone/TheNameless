using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Key : MonoBehaviour
{
    public bool playerHasKey = false;
    private bool inTriggerZone = false;
    public TMP_Text text;
    public GameObject dialogueBox;

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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            inTriggerZone = true;
            text.text = "PRESS [e] TO PICK UP KEY";
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        inTriggerZone = false;
        text.text = " ";
    }
}
