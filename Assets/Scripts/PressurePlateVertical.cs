using UnityEngine;
using UnityEngine.Events;

// This class is for the 'button' GameObject of the pressure plate

public class PressurePlateVertical : MonoBehaviour
{
    [SerializeField] private bool isFlipped = false;
    [SerializeField] private bool toggleable = true;
    private Vector3 startPos;   // The plate's initial position that it will return to after being disengaged
    private readonly float maxPos = 0.1f;   // How far the plate can be depressed
    public UnityEvent onPress;  // Allow us to define the funtion of the pressure plate in the Unity Inspector
    public UnityEvent onRelease;  // Allow us to define what happens when the pressure plate is disengaged
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
        if (!onPlate && (isFlipped ? (transform.position.y > startPos.y) : (transform.position.y < startPos.y)))
            transform.Translate(0, isFlipped ? -0.05f : 0.05f, 0);

        // Check if the pressure plate is fully engaged
        if ((isFlipped ? (transform.position.y >= startPos.y + maxPos) : (transform.position.y <= startPos.y - maxPos)) && !pressed && onPlate)
        {
            pressed = true;
            // If you want do do something just once, do it here
            if (toggleable)
                onPress.Invoke();
        }

        // Set 'pressed' var to false when plate is fully disengaged
        if ((isFlipped ? (transform.position.y <= startPos.y) : (transform.position.y >= startPos.y)) && pressed && !onPlate)
            pressed = false;

        if (pressed)
            gameObject.tag = "Wall";
        else
            gameObject.tag = "Ground";

        //Activates only when held down and deactivates when released
        if (!toggleable)
        {
            if (pressed)
                onPress.Invoke();
            else
                onRelease.Invoke();
        }

    }

    // Functions that detect whether the player or an object are on the pressure plate.
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player") || collision.transform.CompareTag("Object") || collision.transform.CompareTag("Enemy"))
        {
            onPlate = true;
            collision.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision) {
        if (collision.transform.CompareTag("Player") || collision.transform.CompareTag("Object") || collision.transform.CompareTag("Enemy"))
        {
            onPlate = false;
            if (collision.transform.parent.gameObject.activeInHierarchy)
            {
                Transform transform = collision.transform;
                transform.parent = null;
            }
        }

        if (collision.transform.CompareTag("Player")) {
            collision.transform.GetComponent<PlayerMovement>().isOnGround = false;
        }
    }

    public void OnCollisionStay2D(Collision2D collision)
    {
        if ((collision.transform.CompareTag("Player") || collision.transform.CompareTag("Object") || collision.transform.CompareTag("Enemy")) && (isFlipped ? (transform.position.y < startPos.y + maxPos) : (transform.position.y > startPos.y - maxPos)))
        {
            onPlate = true;
            transform.Translate(0, isFlipped ? 0.05f : -0.05f, 0);
        }
    }
}
