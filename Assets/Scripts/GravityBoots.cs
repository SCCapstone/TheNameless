using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GravityBoots : MonoBehaviour
{
    public PlayerMovement playerMovement;
    private bool inTriggerZone = false;
    public TMP_Text text;

    public void Update()
    {
        if (inTriggerZone == true && Input.GetKeyDown(KeyCode.E))
        {
            playerMovement.TurnGravityControlOn();
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            inTriggerZone = true;
            text.text = "PRESS [e] TO PICK UP GRAVITY CONTROL SHOES";
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        inTriggerZone = false;
        text.text = " ";
    }
}