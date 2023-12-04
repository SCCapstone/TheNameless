using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeypressInteract : MonoBehaviour
{
    //Reference to currently interactable game object
    public GameObject interactable;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        //On pressing the interact button while has valid target
        if(Input.GetButtonDown("Fire1") && interactable != null)
        {
            //Switch case for defining the interaction based on the target
            switch(interactable.tag)
            {
                case "Exit":
                    break;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        //Grab the reference for that trigger object
        interactable = collider.gameObject;
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        //If the target is still the object from that trigger (Safety for overlapping triggers)
        if(interactable == collider.gameObject)
        {
            //Remove reference
            interactable = null;
        }
    }
}
