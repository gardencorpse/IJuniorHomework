using UnityEngine;

public class Flipper : MonoBehaviour
{
    [SerializeField] private bool _isLookingRight = true;

    private int _flipAngle = 180;

    public bool IsLookingRight { get; private set; }

    private void Start()
    {
        IsLookingRight = _isLookingRight;

        if (IsLookingRight == false)
        {
            Flip();
        }
    }

    public void Flip()
    {
        IsLookingRight = !IsLookingRight;
        transform.Rotate(0, _flipAngle, 0);
    }
}
