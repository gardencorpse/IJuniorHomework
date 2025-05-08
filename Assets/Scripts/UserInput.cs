using UnityEngine;

public class UserInput : MonoBehaviour
{
    public float HorizontalInput {  get; private set; }
    public bool IsShiftPress { get; private set; }
    public bool IsSpaceDown { get; private set; }

    public void Update()
    {
        HorizontalInput = Input.GetAxis(Constants.Input.HorizontalAxis);
        IsShiftPress = Input.GetKey(KeyCode.LeftShift);
        IsSpaceDown = Input.GetKeyDown(KeyCode.Space);
    }
}
