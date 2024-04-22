using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePistonRight : MonoBehaviour
{
    // Variable Declarations
    public float pistonSpeed = 1;
    public Rigidbody2D myRigidBody;
    [SerializeField] public bool open = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Determines when the piston should move right
    // or go back to its original position
    void Update()
    {
        if(open)
        {
            MovePiston();
        }
        else
        {
            MovePistonBack();
        }
    }

    // Adds a force that moves the piston right
    public void MovePiston()
    {
        myRigidBody.AddForce(transform.right * pistonSpeed, ForceMode2D.Impulse);
    }

    // Adds a force that moves the piston left
    public void MovePistonBack()
    {
        myRigidBody.AddForce(-transform.right * pistonSpeed, ForceMode2D.Impulse);
    }

    // Tells the open variable that it is open
    public void SetOpen(bool isOpen)
    {
        open = isOpen;
    }

}
