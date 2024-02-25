using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ActivateBlink : MonoBehaviour
{
    [SerializeField] Laser laser;
    [SerializeField] float blinkSpeed = 0f;
    [SerializeField] TMP_Text text;
    [SerializeField] private bool inTrigger = false;

    private void Start()
    {
        if(blinkSpeed != 0f)
        {
            laser.ioTimer = blinkSpeed;
        }
    }

    private void Update()
    {
        if(inTrigger && Input.GetKeyDown(KeyCode.E))
        {
            laser.blink = true;
            text.text = "";
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            inTrigger = true;
            text.text = "Press E to activate";
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        inTrigger = false;
    }
}
