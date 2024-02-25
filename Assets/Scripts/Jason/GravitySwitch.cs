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
    [SerializeField]
    private bool switched = false;

    void Start()
    {
        thisAnimator = transform.gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (inTriggerZone == true && Input.GetKeyDown(KeyCode.E))
        {
            switched = !switched;
            text.text = " ";
            onSwitch.Invoke();
        }

        if (onSwitch.GetPersistentMethodName(0) == "ReverseGravity")
            if (Physics2D.gravity.y < 0)
                switched = false;
            else if (Physics2D.gravity.y > 0)
                switched = true;
        
        thisAnimator.SetBool("isSwitched", switched);
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            inTriggerZone = true;
            text.text = "PRESS [e] TO SWITCH LEVER";
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        inTriggerZone = false;
    }
}
