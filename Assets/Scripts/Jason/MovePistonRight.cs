using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePistonRight : MonoBehaviour
{
    public float pistonSpeed = 1;
    public Rigidbody2D myRigidBody;
    [SerializeField] public bool open = false;

    // Start is called before the first frame update
    void Start()
    {
 
    }


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

    public void MovePiston()
    {
        myRigidBody.AddForce(transform.right * pistonSpeed, ForceMode2D.Impulse);
    }

    public void MovePistonBack()
    {
        myRigidBody.AddForce(-transform.right * pistonSpeed, ForceMode2D.Impulse);
    }

    public void SetOpen(bool isOpen)
    {
        open = isOpen;
    }

}
