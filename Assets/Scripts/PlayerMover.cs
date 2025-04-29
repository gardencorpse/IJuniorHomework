using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _runMultiplier = 1.1f;
    [SerializeField] private float _jumpForce = 500f;
    [SerializeField] private GroundChecker _groundChecker;
    [SerializeField] private Animator _animator;

    private CharacterAnimation _characterAnimation;
    private UserInput _userInput;
    private Rigidbody2D _rigidbody;
    private bool _isLookingRigt = true;
    private bool _isGrounded = true;
    private bool _isJumping = false;
    private float _idleParameter = 0f;
    private float _walkParameter = 0.5f;
    private float _runParameter = 1f;

    private void OnEnable()
    {
        _groundChecker.IsGrounded += OnGroundChange;
    }

    private void OnDisable()
    {
        _groundChecker.IsGrounded -= OnGroundChange;
    }

    private void Awake()
    {
        _userInput = gameObject.AddComponent<UserInput>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _characterAnimation = new CharacterAnimation(_animator);
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
        else
        {
            _characterAnimation.ChangeSpeed(_idleParameter);
        }

        if (_userInput.IsSpaceDown)
        {
            Jump();
        }
    }

    private void MoveHorizontal(float horizontalInput)
    {
        float speed = horizontalInput * _speed;

        _rigidbody.linearVelocityX = speed;
        _characterAnimation.ChangeSpeed(_walkParameter);
    }

    private void MoveHorizontal(float horizontalInput, float multiplier = 1)
    {
        float speed = horizontalInput * multiplier * _speed;

        _rigidbody.linearVelocityX = speed;
        _characterAnimation.ChangeSpeed(_runParameter);
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

    private void OnGroundChange(bool isGrounded)
    {
        _isGrounded = isGrounded;

        if (_isGrounded)
        {
            _characterAnimation.PlayGrounded();
            _isJumping = false;
        }
        else if (isGrounded == false && _isJumping == false)
        {
            _characterAnimation.PlayFalling();
        }
    }

    private void Jump()
    {
        if (_isGrounded)
        {
            _isJumping = true;
            _rigidbody.AddForce(new Vector2(0, _jumpForce));
            _characterAnimation.PlayJump();
        }
    }
}
