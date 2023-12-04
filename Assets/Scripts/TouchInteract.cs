using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class will be used to define events that happen automatically when the player touches an object
public class TouchInteract : MonoBehaviour
{
    public SceneChanger sc;
    
    // Start is called before the first frame update
    void Start()
    {
        sc = GetComponent<SceneChanger>();
    }
    
    //This method will contain the interactions for solid objects
    void OnCollisionEnter2D(Collision2D collision)
    {
        //Use this switch case to add interactions based on object tags
        switch(collision.gameObject.tag)
        {
            case "Hazard":
                sc.Reload();
                break;
        }
    }

    //This method will contain the interactions for non-solid objects
    void OnTriggerEnter2D(Collider2D collider)
    {
        //Use this switch case to add interactions based on object tags
        switch(collider.gameObject.tag)
        {
            case "Exit":
                sc.NextLevel();
                break;
        }
    }
}
