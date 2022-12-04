using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiePlayerBehavior : IPlayerBehaviour
{
    private Animator _playerAnimator;
    public DiePlayerBehavior(Animator animator)
    {
        _playerAnimator = animator;
    }

    public void Enter()
    {
        _playerAnimator.SetBool("IsDie", true);
    }

    public void Exit()
    {
        _playerAnimator.SetBool("IsDie", false);
    }

    public void FixedUpdate()
    {

    }

    void IPlayerBehaviour.Update()
    {

    }
}
