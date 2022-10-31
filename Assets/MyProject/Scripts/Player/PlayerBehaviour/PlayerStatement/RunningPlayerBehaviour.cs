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
        DefaultMovement.Move(joystickForMovment.vectorDirection, rb, animator, 0.5f, speed );
        if (joystickForMovment.vectorDirection == Vector2.zero)
        {
            player.SetBehaviourIdle();
        }
    }
}


