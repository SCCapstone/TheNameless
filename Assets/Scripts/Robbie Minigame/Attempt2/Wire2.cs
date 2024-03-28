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
    
    void Start()
    {
        startPos = transform.parent.position;
        wireStartPos = transform.position;
    }

    private void OnMouseDrag()
    {
        Vector3 newPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        newPos.z = 0;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(newPos, 0.2f);
        foreach (Collider2D collider in colliders)
        {
            if(collider.gameObject != gameObject)
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

        UpdateWire(newPos);
        
    }

    /*
    private void OnMouseUp()
    {
        if (wireEnabled)
        {
            UpdateWire(wireStartPos);
            transform.rotation = Quaternion.Euler(Vector3.zero);
        }   
    }
    */

    private void UpdateWire(Vector3 newPos)
    {
        transform.position = newPos;

        Vector3 dir = newPos - startPos;
        transform.right = dir * transform.lossyScale.x;

        float dist = Vector2.Distance(startPos, newPos);
        sr.size = new Vector2(dist, sr.size.y);
    }

    void MatchWire()
    {
        if (wireEnabled)
        {
            wireManager.SuccessfulConnection();
        }
        Destroy(this);
    }
}
