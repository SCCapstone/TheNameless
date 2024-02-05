using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetalCrateScript : MonoBehaviour
{
    private Rigidbody2D myRigidBody;
    private Vector3 localScale;
    private bool isOnGround;

    // Start is called before the first frame update
    void Start()
    {
        localScale = transform.localScale;
        myRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isOnGround = true;
        }
    }

    public void CrateGravityButtonFlip()
    {
        if (isOnGround == true)
        {
            myRigidBody.gravityScale *= -1;
            Vector3 ScalerUP = transform.localScale;
            ScalerUP.y *= -1;
            transform.localScale = ScalerUP;
        }
    }
}
