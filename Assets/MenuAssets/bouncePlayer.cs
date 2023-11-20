using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bouncePlayer : MonoBehaviour
{

    private Rigidbody2D p;

    // Start is called before the first frame update
    void Start()
    {
        p = GetComponent<Rigidbody2D>();
        p.velocity = new Vector2(0.5f,0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (p.velocity.x == 0) {
            p.velocity = new Vector2(0.5f, p.velocity.y);
        }
        if (p.velocity.y == 0)
        {
            p.velocity = new Vector2(p.velocity.x, 0.5f);
        }
    }
}
