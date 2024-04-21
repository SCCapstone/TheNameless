//Caleb Martin
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO:
// Hook animations

public class PlayerControl_NoGrav : MonoBehaviour
{
    //A self-building reference to the player's RigidBody
    private Rigidbody2D rb;

    private SpriteRenderer sprite;
    
    //How fast the player rotates in degrees per second
    public float speed;
    public float force;
    //Input that determines left/right movement
    private float hori;

    // Start is called before the first frame update
    void Start()
    {
        //Hook into your own rigidbody
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //Get how far left or right to move, apply it as a velocity
        hori = Input.GetAxis("Horizontal");
        //Rotate
        rb.rotation += -hori*speed*Time.deltaTime;
        
        //When pressing the gravity button, add an upwards force from the player perspective
        if(Input.GetButton("Jump"))
        {
            rb.AddForce(Quaternion.Euler(0,0,rb.rotation)*Vector3.up*force*Time.deltaTime);
        }
    }
}
