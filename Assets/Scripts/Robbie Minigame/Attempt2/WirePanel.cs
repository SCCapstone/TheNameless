using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WirePanel : MonoBehaviour
{
    [SerializeField] SpriteRenderer sr;
    [SerializeField] GameObject panel;
    [SerializeField] GameObject prompt;
    [SerializeField] GameObject door;
    [SerializeField] WireManager2 wireManager;
    private bool inRange = false;
    private bool inPanel = false;
    private bool hasCompleted = false;

    void Update()
    {
        // if the puzzle is complete, remove text and do not allow the wire panel to open
        if(hasCompleted)
        {
            prompt.GetComponent<TMP_Text>().text = "";
        }
        else
        {
            // alert player to interact
            prompt.GetComponent<TMP_Text>().text = "Press [E] to access Wires";
            
            // if the puzzle is not complete and the player is in range, pressing e disables the prompt and activates the puzzle
            if (door.activeInHierarchy)
            {
                if (inRange && Input.GetKeyDown(KeyCode.E))
                {
                    inPanel = !inPanel;
                    prompt.SetActive(false);
                    if (inPanel)
                    {
                        // sr.enabled = false;
                        panel.SetActive(true);
                    }
                }
            }
            // prompt disabling if the "door" is a laser
            else if (door.GetComponent<Laser>() != null && !door.GetComponent<Laser>().enabled)
            {
                prompt.SetActive(false);
                // sr.enabled = true;
            }
            else
            {
                prompt.SetActive(false);
                // sr.enabled = true;
            }
            // if the wire manager has 4 connections, update the puzzle as completed
            if (wireManager.connections.Count == 4)
            {
                hasCompleted = true;
            }
        }
    }

    // if the player enters the trigger area and the puzzle isn't complete, activate the prompt and tell update that player is in range
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!hasCompleted)
        {
            prompt.SetActive(true);
            inRange = true;
        }
    }

    // if the player exits the trigger area, disable the prompt/panel and tell update player is not in range
    private void OnTriggerExit2D(Collider2D collision)
    {
        inRange = false;
        // sr.enabled = true;
        if (inPanel)
        {
            panel.SetActive(false);
            inPanel = false;
        }
    }
}
