using System;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    [SerializeField] private Collider2D _collider;
    private int _collisionsCount = 0;
    private bool _isGround = true;

    public event Action<bool> Grounded;

    public bool IsGround => _isGround;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent<Platform>(out Platform platform))
        {
            _collisionsCount++;

            if (_collisionsCount == 1)
            {
                _isGround = true;
                Grounded.Invoke(true);
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent<Platform>(out Platform platform))
        {
            _collisionsCount--;

            if (_collisionsCount == 0)
            {
                _isGround = false;
                Grounded.Invoke(false);
            }
        }
    }
}
