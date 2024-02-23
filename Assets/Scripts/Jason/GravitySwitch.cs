using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UIElements;
using UnityEngine.Events;

public class GravitySwitch : MonoBehaviour
{
    private bool inTriggerZone = false;
    public TMP_Text text;
    public UnityEvent onSwitch;

    public Animator thisAnimator;

    void Start()
    {
        thisAnimator = transform.gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(inTriggerZone == true && Input.GetKeyDown(KeyCode.E))
        {
            text.text = " ";
            onSwitch.Invoke();
        }

        if (Physics2D.gravity.y < 0)
        {
            thisAnimator.SetBool("isSwitched", false);
        }
        else if (Physics2D.gravity.y > 0)
        {
            thisAnimator.SetBool("isSwitched", true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            inTriggerZone = true;
            text.text = "Press E to switch lever";
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        inTriggerZone = false;
    }
}
