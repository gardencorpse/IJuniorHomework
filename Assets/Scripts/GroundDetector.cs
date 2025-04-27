using System;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class GroundDetector : MonoBehaviour
{
    public event Action<bool> IsGrounded;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.TryGetComponent<Platform>(out Platform platform))
        {
            IsGrounded.Invoke(true);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent<Platform>(out Platform platform))
        {
            IsGrounded.Invoke(false);
        }
    }
}
