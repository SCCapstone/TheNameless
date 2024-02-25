using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RCMovingPlatform : MonoBehaviour
{
    [SerializeField] private Transform position1, position2;
    [SerializeField] private float speed = 3.0f;

    private void FixedUpdate()
    {
        // Move the platform between position1 and position2
        transform.position = Vector3.MoveTowards(transform.position, GetTargetPosition(), speed);
    }

    private Vector3 GetTargetPosition()
    {
        // Toggle between position1 and position2
        return Vector3.Distance(transform.position, position1.position) < Vector3.Distance(transform.position, position2.position)
            ? position1.position
            : position2.position;
    }

    private void MovePlayerWithPlatform(Collider playerCollider)
    {
        // Calculate the offset to maintain the player's position relative to the platform
        Vector3 offset = playerCollider.transform.position - transform.position;

        // Move the player along with the platform
        playerCollider.transform.position = transform.position + offset;
    }

    private void OnCollisionStay(Collision collision)
    {
        foreach (ContactPoint contact in collision.contacts)
        {
            // Check if the collision is below the platform
            if (Vector3.Dot(contact.normal, Physics.gravity.normalized) < -0.9f)
            {
                // Move the player with the platform
                MovePlayerWithPlatform(collision.collider);
            }
        }
    }
}