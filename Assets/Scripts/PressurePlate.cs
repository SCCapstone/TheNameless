using UnityEngine;
using UnityEngine.Events;

public class PressurePlate : MonoBehaviour
{
    private Vector3 startPos;
    private readonly float maxPos = 0.1f;
    public UnityEvent onPress;
    private bool onPlate;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        onPlate = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!onPlate && transform.position.y < startPos.y)
            transform.Translate(0, 0.05f, 0);

        if (transform.position.y <= startPos.y - maxPos) {
            onPress.Invoke();
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
