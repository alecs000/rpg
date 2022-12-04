using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdlePlayerBehaviour : IPlayerBehaviour
{
    private Rigidbody2D _playerRigidbody;
    private Animator _playerAnimator;

    public IdlePlayerBehaviour(Rigidbody2D rb, Animator anim)
    {
        this._playerRigidbody = rb;
        _playerAnimator = anim;
    }

    public void Enter()
    {
        _playerAnimator.SetBool("IsDie", false);
        _playerAnimator.SetBool("IdleActive", true);
    }

    public void Exit()
    {
        _playerAnimator.SetBool("IdleActive", false);

    }

    public void FixedUpdate()
    {
        _playerRigidbody.velocity = Vector2.zero;
    }

    void IPlayerBehaviour.Update()
    {
    }
}
