//Caleb Martin
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO:
// Hook animations

public class PlayerControl_NoGrav : MonoBehaviour
{
    //A self-building reference to the player's RigidBody
    public Rigidbody2D rb;
    public SceneChanger sc;
    //How fast the player rotates in degrees per second
    public float speed;
    public float force;
    //Input that determines left/right movement
    private float hori;
    
    public float respawnX;
    public float respawnY;

    // Start is called before the first frame update
    void Start()
    {
        //Hook into your own rigidbody
        rb = GetComponent<Rigidbody2D>();
        sc = GetComponent<SceneChanger>();
    }

    // Update is called once per frame
    void Update()
    {
        //Get how far left or right to move, apply it as a velocity
        hori = Input.GetAxis("Horizontal");
        rb.rotation += -hori*speed*Time.deltaTime;
        
        //When pressing the gravity button, switch the gravity scale and jump direction
        if(Input.GetButton("Vertical"))
        {
            rb.AddForce(Quaternion.Euler(0,0,rb.rotation)*Vector3.up*force*Time.deltaTime);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        switch(collision.gameObject.tag)
        {
            case "Hazard":
                transform.position = new Vector2(respawnX,respawnY);
                rb.rotation = 0f;
                break;
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Exit")
        {
            sc.NextLevel();
        }
    }
}
