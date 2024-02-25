using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePistonLeft : MonoBehaviour
{
    public float pistonSpeed = 1;
    public Rigidbody2D myRigidBody2;
    public bool press = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void FixedUpdate()
    {

        if (press == true)
        {
            MovePiston();
        }
        else if (press == false)
        {
            MovePistonBack();
        }
    }

    public void MovePiston()
    {
        myRigidBody2.AddForce(-transform.right * pistonSpeed, ForceMode2D.Impulse);
    }

    public void MovePistonBack()
    {
        myRigidBody2.AddForce(transform.right * pistonSpeed, ForceMode2D.Impulse);
    }

    
}
