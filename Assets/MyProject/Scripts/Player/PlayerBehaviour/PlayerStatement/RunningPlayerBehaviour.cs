using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunningPlayerBehaviour : IPlayerBehaviour
{
    private Rigidbody2D rb;
    private float speed;
    private Animator animator;
    private JoystickForMovment joystickForMovment;
    private Player player;
    public RunningPlayerBehaviour(Rigidbody2D rb, float speed, Animator animator, JoystickForMovment joystickForMovment, Player player)
    {
        this.rb = rb;
        this.speed = speed;
        this.animator = animator;
        this.joystickForMovment = joystickForMovment;
        this.player = player;
    }

    public void Enter()
    {
        animator.SetBool("IdleActive", false);
    }

    public void Exit()
    {
        rb.velocity = Vector3.zero; 
        animator.SetBool("IdleActive", true);
        animator.SetInteger("Direction", 4);
    }

    public void Update()
    {
        
    }

    void IPlayerBehaviour.FixedUpdate()
    {
        Vector2 dir = joystickForMovment.vectorDirection;
        if (dir.y > 0.5 || dir.x > 0.5 || dir.y < -0.5 || dir.x < -0.5)
        {
            DefaultMovement.Move(dir, rb, speed);
        }
        DefaultMovement.MoveAnimation(joystickForMovment.vectorDirection,animator, 0.5f);
        if (joystickForMovment.vectorDirection == Vector2.zero)
        {
            player.SetBehaviourIdle();
        }
    }
}


