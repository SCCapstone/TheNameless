using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GravityBoots : MonoBehaviour
{
    // Variable Declarations
    public PlayerMovement playerMovement;
    private bool inTriggerZone = false;
    public TMP_Text text;

    // Allows the player to pick up gravity boots
    // and removes the boots from the ground
    public void Update()
    {
        if (inTriggerZone == true && Input.GetKeyDown(KeyCode.E))
        {
            playerMovement.TurnGravityControlOn();
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            gameObject.SetActive(false);
        }

    }

    // Reminds player that they can pick up the gravity boots
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            inTriggerZone = true;
            text.text = "PRESS [e] TO PICK UP GRAVITY CONTROL SHOES";
        }
    }

    // Gets rid of the text message when they go away from the gravity boots
    private void OnTriggerExit2D(Collider2D collision)
    {
        inTriggerZone = false;
        text.text = " ";
    }
}
