using UnityEngine;

public class bouncePlayer : MonoBehaviour
{

    private Rigidbody2D p;
    private Vector2 lastVelocity;

    // Start is called before the first frame update
    void Start()
    {
        p = GetComponent<Rigidbody2D>();
        p.AddForce(new Vector2(Random.Range(2, 4) * (Random.Range(0, 2) < 1 ? -10 : 10), Random.Range(2, 4) * (Random.Range(0, 2) < 1 ? -10 : 10)));
        p.AddTorque(0.4f);
    }

    // Update is called once per frame
    void Update()
    {
        lastVelocity = p.velocity;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        p.velocity = Vector2.Reflect(lastVelocity, collision.contacts[0].normal);
    }
}
