using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _runMultiplier = 1.1f;
    [SerializeField] private float _jumpForce = 500f;
    [SerializeField] private UserInput _userInput;
    [SerializeField] private GroundChecker _groundChecker;
    [SerializeField] private Animator _animator;

    private CharacterAnimation _characterAnimation;
    private Rigidbody2D _rigidbody;
    private Flipper _flipper;
    private bool _isLookingRight = true;
    private bool _isGrounded = true;
    private bool _isJumping = false;
    private bool _isJump = false;
    private float _idleParameter = 0f;
    private float _walkParameter = 0.5f;
    private float _runParameter = 1f;

    private void Awake()
    {
        _userInput = gameObject.AddComponent<UserInput>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _characterAnimation = new CharacterAnimation(_animator);
        _flipper = new Flipper(transform, _isLookingRight);
    }

    private void OnEnable()
    {
        _groundChecker.IsGrounded += OnGroundChange;
    }

    private void OnDisable()
    {
        _groundChecker.IsGrounded -= OnGroundChange;
    }

    private void Update()
    {
        if (_userInput.IsSpaceDown)
            _isJump = true;
    }

    private void FixedUpdate()
    {
        if (_userInput.HorizontalInput != 0)
        {
            if (_userInput.IsShiftPress)
            {
                MoveHorizontal(_userInput.HorizontalInput, _runParameter, _runMultiplier);
            }
            else
            {
                MoveHorizontal(_userInput.HorizontalInput, _walkParameter);
            }

            UpdateLookDirection();
        }
        else
        {
            _characterAnimation.ChangeSpeed(_idleParameter);
        }

        if (_isJump)
            Jump();
    }

    private void MoveHorizontal(float horizontalInput, float animationParametr, float multiplier = 1)
    {
        float speed = horizontalInput * multiplier * _speed;

        _rigidbody.linearVelocityX = speed;
        _characterAnimation.ChangeSpeed(animationParametr);
    }

    private void UpdateLookDirection()
    {
        if (_flipper.IsLookingRigt && _userInput.HorizontalInput < 0)
        {
            _flipper.Flip();
        }
        else if (_flipper.IsLookingRigt == false && _userInput.HorizontalInput > 0)
        {
            _flipper.Flip();
        }
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
        _isJump = false;

        if (_isGrounded)
        {
            _isJumping = true;
            _rigidbody.AddForce(new Vector2(0, _jumpForce));
            _characterAnimation.PlayJump();
        }
    }
}
