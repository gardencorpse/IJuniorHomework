using System;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    [SerializeField] private GroundDetector _detector;
    //public bool IsGround { get; private set; } = false;

    public event Action<bool> IsGrounded;

    private void OnEnable()
    {
        _detector.IsGrounded += OnGroundChange;
    }

    private void OnDisable()
    {
        _detector.IsGrounded -= OnGroundChange;
    }

    private void OnGroundChange(bool isGround)
    {
        //IsGround = isGround;
        IsGrounded.Invoke(isGround);
    }


}
