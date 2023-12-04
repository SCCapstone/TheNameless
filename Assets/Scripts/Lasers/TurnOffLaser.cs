using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TurnOffLaser : MonoBehaviour
{
    [SerializeField] Laser laser;
    [SerializeField] TMP_Text text;
    private bool inTrigger = false;
    private void Update()
    {
        // if the player is in the trigger box and presses E, the laser will be disabled
        if(inTrigger && Input.GetKeyDown(KeyCode.E))
        {
            laser.playerTag = "Disabled";
            laser.posCount = 0;
            text.text = "";
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // if the player enters the trigger box, set the bool to true
        if(collision.tag == "Player")
        {
            inTrigger = true;
            text.text = "Press E to activate";
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // if the player exits the box, set bool to false
        inTrigger = false;
    }
}
