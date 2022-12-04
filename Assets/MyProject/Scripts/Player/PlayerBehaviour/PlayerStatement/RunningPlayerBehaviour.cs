using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunningPlayerBehaviour : IPlayerBehaviour
{
    private Rigidbody2D _playerRididbody;
    private float _speed;
    private Animator _playerAnimator;
    private JoystickForMovment _joystickForMovment;
    private Player _player;
    public RunningPlayerBehaviour(Rigidbody2D playerRididbody, float speed, Animator animator, JoystickForMovment joystickForMovment, Player player)
    {
        this._playerRididbody = playerRididbody;
        this._speed = speed;
        this._playerAnimator = animator;
        this._joystickForMovment = joystickForMovment;
        this._player = player;
    }

    public void Enter()
    {
        _playerAnimator.SetBool("IdleActive", false);
    }

    public void Exit()
    {
        _playerRididbody.velocity = Vector3.zero; 
        _playerAnimator.SetInteger("Direction", 4);
    }

    public void Update()
    {
        
    }

    void IPlayerBehaviour.FixedUpdate()
    {
        Vector2 dir = _joystickForMovment.VectorDirection;
        if (dir.y > 0.5 || dir.x > 0.5 || dir.y < -0.5 || dir.x < -0.5)
        {
            DefaultMovement.Move(dir, _playerRididbody, _speed);
        }
        DefaultMovement.MoveAnimation(_joystickForMovment.VectorDirection,_playerAnimator, 0.5f);
        if (_joystickForMovment.VectorDirection == Vector2.zero)
        {
            _player.SetBehaviourIdle();
        }
    }
}


