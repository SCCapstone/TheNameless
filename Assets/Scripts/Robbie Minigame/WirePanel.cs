using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WirePanel : MonoBehaviour
{
    [SerializeField] SpriteRenderer sr;
    [SerializeField] GameObject panel;
    [SerializeField] GameObject prompt;
    private bool inRange = false;
    private bool inPanel = false;
    void Update()
    {
        if (inRange && Input.GetKeyDown(KeyCode.E))
        {
            inPanel = !inPanel;
            prompt.SetActive(false);
        }

        if (inPanel)
        {
            sr.enabled = false;
            panel.SetActive(true);
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
