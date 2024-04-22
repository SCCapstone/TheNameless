using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wire2 : MonoBehaviour
{
    [SerializeField] SpriteRenderer sr;
    [SerializeField] WireManager2 wireManager;
    bool wireEnabled = true;
    Vector3 startPos;
    Vector3 wireStartPos;
    
    // log the start position of the wire and parent object
    void Start()
    {
        startPos = transform.parent.position;
        wireStartPos = transform.position;
    }

    // if the object gets disabled, snap wire to start postion
    private void OnDisable()
    {
        OnMouseUp();
    }

    // handler for dragging wire
    private void OnMouseDrag()
    {
        // vector to hold mouse position
        Vector3 newPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        newPos.z = 0;

        // check all overlapping colliders for matching wire that is not itself
        Collider2D[] colliders = Physics2D.OverlapCircleAll(newPos, 0.2f);
        foreach (Collider2D collider in colliders)
        {
            if(collider.gameObject != gameObject && collider.gameObject.tag == "Wire")
            {
                
                UpdateWire(collider.transform.position);
                
                if(transform.parent.name.Equals(collider.transform.parent.name))
                {
                    wireEnabled = false;
                    collider.GetComponent<Wire2>()?.MatchWire();
                    MatchWire();
                }

                return;
            }
        }

        // use the mouse position to update the wire's position
        UpdateWire(newPos);
        
    }

    // when the mouse is released, snap the wire back to start position
    private void OnMouseUp()
    {
        if (wireEnabled)
        {
            UpdateWire(wireStartPos);
            transform.rotation = Quaternion.Euler(Vector3.zero);
        }   
    }
    
    // update the wire's position, rotation, and scale
    private void UpdateWire(Vector3 newPos)
    {
        // change position
        transform.position = newPos;

        // change rotation relative to the parent object
        Vector3 dir = newPos - startPos;
        transform.right = dir * transform.lossyScale.x;

        // change scale based on distance
        float dist = Vector2.Distance(startPos, newPos);
        sr.size = new Vector2(dist, sr.size.y);
    }

    // if the wire connects to it's matching wire, update the puzzle manager and distroy it's functionality
    void MatchWire()
    {
        if (wireEnabled)
        {
            wireManager.SuccessfulConnection();
        }
        Destroy(this);
    }
}
