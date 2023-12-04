using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireBehavior : MonoBehaviour
{
    [SerializeField] Transform respawn;
    [SerializeField] string respawnTag = "Player";

    /* 
        TODO
                Flashing effect
                Play Animation (Jason)
                particle system control for sparks
     */

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == respawnTag)
        {
            collision.gameObject.transform.position = respawn.position;
        }
    }

    public void DisableWires()
    {
        respawnTag = "Disabled";
    }
}
