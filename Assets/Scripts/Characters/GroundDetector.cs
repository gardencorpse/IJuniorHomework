using System;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class GroundDetector : MonoBehaviour
{
    public bool IsGround { get; private set; } = false;
    public event Action<bool> IsGrounded;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent<Platform>(out Platform platform))
        {
            IsGround = true;
            IsGrounded.Invoke(true);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent<Platform>(out Platform platform))
        {
            IsGround = false;
            IsGrounded.Invoke(false);
        }
    }
}
