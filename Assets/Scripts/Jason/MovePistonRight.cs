using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePistonRight : MonoBehaviour
{
    public float pistonSpeed = 1;
    public Rigidbody2D myRigidBody;
    [SerializeField] public bool open = false;
    public PistonTriggerZone trigger;

    // Start is called before the first frame update
    void Start()
    {
       trigger = GameObject.FindGameObjectWithTag("TriggerZone").GetComponent<PistonTriggerZone>();
    }


    public void FixedUpdate()
    {
        if(open)
        {
            MovePiston();
            if(trigger.detected == true)
            {
                myRigidBody.velocity = Vector3.zero;
            }
        }
        else
        {
            trigger.detected = false;
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
