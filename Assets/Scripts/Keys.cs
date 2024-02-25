using UnityEngine;
using UnityEngine.Events;

public class CollisionDetector : MonoBehaviour
{
    [SerializeField]
    private string _colliderScript;

    [SerializeField]
    private UnityEvent _collisionEntered;

    [SerializeField]
    private UnityEvent _collisionExited;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent(_colliderScript))
        {
            _collisionEntered?.Invoke();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent(_colliderScript))
        {
            _collisionExited?.Invoke();
        }
    }
}