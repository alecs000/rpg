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

    void IPlayerBehaviour.Update()
    {
        rb.velocity = speed * joystickForMovment.vectorDirection;
        if((animator.GetInteger("Direction") == 0&& joystickForMovment.vectorDirection.y > 0.5)|| (animator.GetInteger("Direction") == 1 && joystickForMovment.vectorDirection.x > 0.5)|| (animator.GetInteger("Direction") == 2 && joystickForMovment.vectorDirection.y < -0.5)|| (animator.GetInteger("Direction") == 3 && joystickForMovment.vectorDirection.x < -0.5))
        {
            return;
        }
        if (joystickForMovment.vectorDirection.y > 0.5)
        {
            Debug.Log("ER");
            animator.SetInteger("Direction", 0);
            return;
        }
        if (joystickForMovment.vectorDirection.x > 0.5)
        {
            animator.SetInteger("Direction", 1);
            return;
        }
        if (joystickForMovment.vectorDirection.y < -0.5)
        {
            animator.SetInteger("Direction", 2);
            return;
        }
        if (joystickForMovment.vectorDirection.x < -0.5)
        {
            animator.SetInteger("Direction", 3);
            return;
        }
        if (joystickForMovment.vectorDirection == Vector2.zero)
        {
            player.SetBehaviourIdle();
        }
    }
}


