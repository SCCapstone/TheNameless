using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistonTriggerZone : MonoBehaviour
{
    private void Start()
    {
        GameObject crate = GameObject.FindGameObjectWithTag("Object");
        Physics2D.IgnoreCollision(crate.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }
}
