using UnityEngine;

public class Flipper
{
    private Transform _transform;
    private int _flipAngle = 180;
    public bool IsLookingRigt {  get; private set; }

    public Flipper(Transform transform, bool isLookingRigt)
    {
        _transform = transform;
        IsLookingRigt = isLookingRigt;

        if(IsLookingRigt == false)
        {
            Flip();
        }
    }

    public void Flip()
    {
        IsLookingRigt = !IsLookingRigt;
        _transform.Rotate(0, _flipAngle, 0);
    }
}
