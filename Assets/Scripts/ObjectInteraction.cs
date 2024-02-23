using System;
using System.Collections;
using UnityEngine;

// This class is for the 'Player' GameObject

public class ObjectInteraction : MonoBehaviour
{
    [SerializeField] private Transform grabPoint;   // Child to the Player GameObject, position of objects that will be grabbed
    private GameObject gObject;                     // Grabbed object
    private GameObject tObject;                     // Touched object
    private Rigidbody2D rb;                         // RigidBody2D of the Player
    private GameObject tCanvas;
    private bool firstTouch;

    
    void Start()
    {
        gObject = null;
        tObject = null;
        rb = GetComponent<Rigidbody2D>();
        tCanvas = null;
        firstTouch = true;
    }

    void Update()
    {
        // If the object has been 'grabbed', update it's position to the player's grab position
        if (gObject != null)
            gObject.transform.position = grabPoint.position;

        // Press 'E' to pick up a new object
        if (Input.GetKeyDown(KeyCode.E) && gObject != tObject)
        {
            gObject = tObject;
            gObject.GetComponent<Rigidbody2D>().isKinematic = true;
            gObject.transform.SetParent(transform);
        }
        // Press 'E' to release the currently held object
        else if (Input.GetKeyDown(KeyCode.E))
        {
            gObject.GetComponent<Rigidbody2D>().isKinematic = false;
            gObject.transform.SetParent(null);
            // Allow the object to keep moving with the same velocity as when it was released
            gObject.GetComponent<Rigidbody2D>().velocity = new Vector2(rb.velocity.x, rb.velocity.y);
            gObject = null;
        }

        if (tObject != null)
        {
            try {
                tCanvas = tObject.transform.GetChild(1).gameObject;
            } catch (Exception)
            {}

            if (tCanvas != null && firstTouch)
            {
                StartCoroutine(DisplayInstructions(tCanvas));
                firstTouch = false;
            }
        }

    }

    // Functions that detect whether the player is touching an object
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Object"))
            tObject = collider.gameObject;
    }

    private void OnTriggerExit2D(Collider2D collider) 
    {
        if (collider.gameObject.CompareTag("Object"))
            tObject = null;
    }

    IEnumerator DisplayInstructions(GameObject canvas)
    {
        yield return null;
        canvas.SetActive(true);
        yield return new WaitForSeconds(3f);
        canvas.SetActive(false);
    }
}
