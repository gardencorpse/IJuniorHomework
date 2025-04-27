using System;
using Unity.VisualScripting;
using UnityEditor.SceneManagement;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _runMultiplier = 1.1f;
    [SerializeField] private float _jumpForce = 500f;
    [SerializeField] private GroundChecker _groundChecker;

    private UserInput _userInput;
    private Rigidbody2D _rigidbody;
    private bool _isLookingRigt = true;

    private void Awake()
    {
        _userInput = gameObject.AddComponent<UserInput>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (_userInput.HorizontalInput != 0)
        {
            if (_userInput.IsShiftPress)
            {
                MoveHorizontal(_userInput.HorizontalInput, _runMultiplier);
            }
            else
            {
                MoveHorizontal(_userInput.HorizontalInput);
            }

            CheckLookDirection();
        }

        if (_userInput.IsSpaceDown)
        {
            Jump();
        }
    }

    private void MoveHorizontal(float horizontalInput, float multiplier = 1)
    {
        _rigidbody.linearVelocityX = horizontalInput * multiplier * _speed;
    }

    private void CheckLookDirection()
    {
        if (_isLookingRigt && _userInput.HorizontalInput < 0)
        {
            Flip();
        }
        else if (_isLookingRigt == false && _userInput.HorizontalInput > 0)
        {
            Flip();
        }
    }

    private void Flip()
    {
        _isLookingRigt = !_isLookingRigt;
        transform.Rotate(0, 180, 0);
    }

    private void Jump()
    {
        if (_groundChecker.IsGround)
        {
            _rigidbody.AddForce(new Vector2(0, _jumpForce));
        }
    }
}
