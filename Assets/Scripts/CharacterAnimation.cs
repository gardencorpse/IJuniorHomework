using UnityEngine;

public class CharacterAnimation
{
    private Animator _animator;

    public CharacterAnimation(Animator animator)
    {
        _animator = animator;
    }

    public void ChangeSpeed(float speed) =>
        _animator.SetFloat(Constants.Animation.Speed, speed);

    public void PlayJump() =>
        _animator.SetTrigger(Constants.Animation.Jump);

    public void PlayGrounded() =>
        _animator.SetTrigger(Constants.Animation.Grounded);

    public void PlayFalling() =>
    _animator.SetTrigger(Constants.Animation.Fall);
}
