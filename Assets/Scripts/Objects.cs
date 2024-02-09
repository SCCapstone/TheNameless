using UnityEngine;

public class Objects : MonoBehaviour
{
    [SerializeField]
    private Transform grabPoint;
    private GameObject gObject;
    private GameObject tObject;
    private Rigidbody2D rb;

    
    void Start()
    {
        gObject = null;
        tObject = null;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

        if (gObject != null)
            gObject.transform.position = grabPoint.position;

        if (Input.GetKeyDown(KeyCode.E) && gObject != tObject)
        {
            gObject = tObject;
            gObject.GetComponent<Rigidbody2D>().isKinematic = true;
            gObject.transform.SetParent(transform);
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            gObject.GetComponent<Rigidbody2D>().isKinematic = false;
            gObject.transform.SetParent(null);
            gObject.GetComponent<Rigidbody2D>().velocity = new Vector2(rb.velocity.x, rb.velocity.y);
            gObject = null;
        }

    }

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
}
