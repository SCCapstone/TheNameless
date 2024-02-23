using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UIElements;

public class GravitySwitch : MonoBehaviour
{
    public Animator rightAnimator;
    public Animator leftAnimator;
    private bool isSwitched = false;
    private bool inTriggerZone = false;
    public TMP_Text text;
    private Vector3 localScale;

    // Update is called once per frame
    void Update()
    {
        if(inTriggerZone == true && Input.GetKeyDown(KeyCode.E))
        {
            text.text = " ";
            if(isSwitched == true)
            {
                rightAnimator.SetBool("isSwitched", true);
                leftAnimator.SetBool("isSwitched", true);
            }
            if(isSwitched == false)
            {
                rightAnimator.SetBool("isSwitched", false);
                leftAnimator.SetBool("isSwitched", false);
            }
            Physics2D.gravity = new Vector2(Physics2D.gravity.x, -Physics2D.gravity.y);
            Vector3 scale = transform.localScale;
            if ((scale.y < 0 && Physics2D.gravity.y < 0) || (scale.y > 0 && Physics2D.gravity.y > 0))
                scale.y *= -1;
            transform.localRotation = Quaternion.Euler(0, 0, 0);
            transform.localScale = scale;
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
