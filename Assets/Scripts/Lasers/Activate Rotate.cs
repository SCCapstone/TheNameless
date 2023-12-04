using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ActivateRotate : MonoBehaviour
{
    [SerializeField] Laser laser;
    [SerializeField] float rotateTimer = 0f;
    [SerializeField] TMP_Text text;
    [SerializeField] private bool inTrigger = false;

    private void Start()
    {
        if(rotateTimer != 0f)
        {
            laser.rotateTimer = rotateTimer;
        }
    }

    private void Update()
    {
        if (inTrigger && Input.GetKeyDown(KeyCode.E))
        {
            laser.moving = true;
            text.text = "";
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            text.text = "Press E to activate";
            inTrigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        inTrigger = false;
    }
}
