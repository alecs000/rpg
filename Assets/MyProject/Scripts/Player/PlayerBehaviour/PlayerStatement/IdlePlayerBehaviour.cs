using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdlePlayerBehaviour : IPlayerBehaviour
{
    private Rigidbody2D _playerRigidbody;

    public IdlePlayerBehaviour(Rigidbody2D rb)
    {
        this._playerRigidbody = rb;
    }

    public void Enter()
    {
        Debug.Log("Enter Idle State");
    }

    public void Exit()
    {
        Debug.Log("Exit Idle State");

    }

    public void FixedUpdate()
    {
        _playerRigidbody.velocity = Vector2.zero;
    }

    void IPlayerBehaviour.Update()
    {
    }
}
