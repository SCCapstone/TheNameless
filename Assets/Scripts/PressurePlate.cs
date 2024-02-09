using UnityEngine;
using UnityEngine.Events;

public class PressurePlate : MonoBehaviour
{
    private Vector3 startPos;
    private readonly float maxPos = 0.1f;
    public UnityEvent onPress;
    private bool onPlate;
    private bool activationToggle;
    private bool pressed;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        onPlate = false;
        activationToggle = false;
        pressed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!onPlate && transform.position.y < startPos.y)
            transform.Translate(0, 0.05f, 0);

        if (transform.position.y <= startPos.y - maxPos && !pressed)
        {
            pressed = true;
            activationToggle = !activationToggle;
            // If you want do do something just once, do it here
            onPress.Invoke();
        }

        if (transform.position.y >= startPos.y && pressed == true)
            pressed = false;

        if (activationToggle)
        {
            // Do something here
        }

    }

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
