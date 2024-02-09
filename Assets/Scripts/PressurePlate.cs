using UnityEngine;
using UnityEngine.Events;

// This class is for the 'button' GameObject of the pressure plate

public class PressurePlate : MonoBehaviour
{
    private Vector3 startPos;   // The plate's initial position that it will return to after being disengaged
    private readonly float maxPos = 0.1f;   // How far the plate can be depressed
    public UnityEvent onPress;  // Allow us to define the funtion of the pressure plate in the Unity Inspector
    private bool onPlate;       // Whether something is making contact with the plate
    private bool pressed;       // Bool to make sure the plate can't be activated again until it's fully disengaged first

    // Start is called before the first frame update
    void Start()
    {
        // Pressure plate should start in the open position
        startPos = transform.position;
        onPlate = false;
        pressed = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Restore plate to it's original position if nothing is on the plate
        if (!onPlate && transform.position.y < startPos.y)
            transform.Translate(0, 0.05f, 0);

        // Check if the pressure plate is fully engaged
        if (transform.position.y <= startPos.y - maxPos && !pressed && onPlate)
        {
            pressed = true;
            // If you want do do something just once, do it here
            onPress.Invoke();
        }

        // Set 'pressed' var to false when plate is fully disengaged
        if (transform.position.y >= startPos.y && pressed && !onPlate)
            pressed = false;

    }

    // Functions that detect whether the player or an object are on the pressure plate.
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player") || collision.transform.CompareTag("Object"))
        {
            onPlate = true;
            collision.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision) {
        if (collision.transform.CompareTag("Player") || collision.transform.CompareTag("Object"))
        {
            onPlate = false;
            collision.transform.SetParent(null);
        }
    }

    public void OnCollisionStay2D(Collision2D collision)
    {
        if ((collision.transform.CompareTag("Player") || collision.transform.CompareTag("Object")) && transform.position.y > startPos.y - maxPos)
        {
            onPlate = true;
            transform.Translate(0, -0.05f, 0);
        }
    }
}
