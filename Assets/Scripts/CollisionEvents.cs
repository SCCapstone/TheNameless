using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class CollisionEvents : MonoBehaviour
{
    [SerializeField] private UnityEvent _onTriggerEnter;

    private void OnTriggerEnter2D(Collider2D other)
    {
        var player = other.GetComponent<PlayerMovement>();
        if (player != null)
        {
            _onTriggerEnter?.Invoke();
        }
    }
}
