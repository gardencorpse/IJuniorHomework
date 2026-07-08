using UnityEngine;

public class EnemyAnimator
{
    private Animator _animator;

    public EnemyAnimator(Animator animator)
    {
        _animator = animator;
    }

    public void ChangeAttackState(bool isAttack) =>
        _animator.SetBool(Constants.Animation.isAttack, isAttack);


}
