using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WirePanel : MonoBehaviour
{
    [SerializeField] SpriteRenderer sr;
    [SerializeField] GameObject panel;
    [SerializeField] GameObject prompt;
    [SerializeField] GameObject door;
    private bool inRange = false;
    private bool inPanel = false;
    void Update()
    {
        if (door.activeInHierarchy)
        {
            if (inRange && Input.GetKeyDown(KeyCode.E))
            {
                inPanel = !inPanel;
                prompt.SetActive(false);
                if(inPanel)
                {
                    sr.enabled = false;
                    panel.SetActive(true);
                }
            }
        }
        else if (door.GetComponent<Laser>() != null && !door.GetComponent<Laser>().enabled)
        {
            prompt.SetActive(false);
            sr.enabled = true;
        }
        else
        {
            prompt.SetActive(false);
            sr.enabled = true;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        prompt.SetActive(true);
        inRange = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        inRange = false;
        sr.enabled = true;
        if (inPanel)
        {
            panel.SetActive(false);
            inPanel = false;
        }
    }
}
