using System;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    [SerializeField] private List<GroundDetector> _detectors;
    private bool _isGround = true;
    private List<bool> _isGrounds = new List<bool>();

    public event Action<bool> IsGrounded;

    private void Awake()
    {
        foreach (var detector in _detectors)
        {
            _isGrounds.Add(detector.IsGround);
        }
    }

    private void OnEnable()
    {
        foreach (var detector in _detectors)
        {
            detector.IsGrounded += OnGroundChange;
        }
    }

    private void OnDisable()
    {
        foreach (var detector in _detectors)
        {
            detector.IsGrounded -= OnGroundChange;
        }
    }

    private void OnGroundChange(bool isGround)
    {
        if (_isGround == isGround)
            return;

        foreach (var detector in _detectors)
        {
            if (detector.IsGround)
            {
                if (_isGround)
                    return;

                _isGround = true;
                IsGrounded.Invoke(true);
                return;
            }
        }

        _isGround = false;
        IsGrounded.Invoke(false);
    }
}
