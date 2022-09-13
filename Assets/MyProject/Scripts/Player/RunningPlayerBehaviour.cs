using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunningPlayerBehaviour : IPlayerBehaviour
{
    private Rigidbody2D rb;
    private float speed;
    private Animator animator;

    public RunningPlayerBehaviour(Rigidbody2D rb, float speed, Animator animator)
    {
        this.rb = rb;
        this.speed = speed;
        this.animator = animator;
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
        rb.velocity = speed * JoystickForMovment.vectorDirection;
        if((animator.GetInteger("Direction") == 0&& JoystickForMovment.vectorDirection.y > 0.5)|| (animator.GetInteger("Direction") == 1 && JoystickForMovment.vectorDirection.x > 0.5)|| (animator.GetInteger("Direction") == 2 && JoystickForMovment.vectorDirection.y < -0.5)|| (animator.GetInteger("Direction") == 3 && JoystickForMovment.vectorDirection.x < -0.5))
        {
            return;
        }
        if (JoystickForMovment.vectorDirection.y > 0.5)
        {
            Debug.Log("ER");
            animator.SetInteger("Direction", 0);
            return;
        }
        if (JoystickForMovment.vectorDirection.x > 0.5)
        {
            animator.SetInteger("Direction", 1);
            return;
        }
        if (JoystickForMovment.vectorDirection.y < -0.5)
        {
            animator.SetInteger("Direction", 2);
            return;
        }
        if (JoystickForMovment.vectorDirection.x < -0.5)
        {
            animator.SetInteger("Direction", 3);
            return;
        }
    }
}


