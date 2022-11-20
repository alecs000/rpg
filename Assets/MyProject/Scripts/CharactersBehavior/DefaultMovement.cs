using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;
using static UnityEngine.RuleTile.TilingRuleOutput;

public static class DefaultMovement
{
    /// <summary>
    /// Try to move _agent. If trigger set by default, then "Movement in 4 corners" is called, otherwise the "Movement in 4 direction" is called.
    /// </summary>
    /// <param name="trigger">If trigger set by default, then "Movement in 4 corners" is called, otherwise the "Movement in 4 direction" is called.</param>
    public static bool TryMoveAgent(Vector2 MoveFrom, Vector2 MoveTo, Animator anim, float distance, NavMeshAgent agent, bool trigger = true)
    {
        float dis = Vector3.Distance(MoveTo, MoveFrom);
        Vector2 direction = (MoveTo - MoveFrom).normalized;
        if (dis > distance)
        {
            if (trigger)
            {
                if (direction.y > 0 || direction.x > 0 || direction.y < -0 || direction.x < -0)
                {
                    agent.SetDestination(MoveTo);
                }
            }
            if (direction.y > 0.5 || direction.x > 0.5 || direction.y < -0.5 || direction.x < -0.5)
            {
                agent.SetDestination(MoveTo);
            }
            MoveAnimation(direction, anim, 0.5f);
            return true;
        }
        else
        {
            anim.SetInteger("Direction", 4);
            return false;
        }
    }
    /// <summary>
    /// Try to move. If trigger set by default, then "Movement in 4 corners" is called, otherwise the "Movement in 4 direction" is called.
    /// </summary>
    /// <param name="trigger">If trigger set by default, then "Movement in 4 corners" is called, otherwise the "Movement in 4 direction" is called.</param>
    public static bool TryMove(Vector2 MoveFrom, Vector2 MoveTo, Rigidbody2D rb, Animator anim, float distance, float speed = 2, float trigger = -10)
    {
        float dis = Vector3.Distance(MoveTo, MoveFrom);
        Vector2 dir = (MoveTo - MoveFrom).normalized;
        if (dis > distance)
        {
            if (trigger == -10)
            {
                if (dir.y > 0 || dir.x > 0 || dir.y < -0 || dir.x < -0)
                {
                    Move(dir, rb, speed);
                }
                MoveAnimation(dir, anim);
                return true;
            }
            if (dir.y > trigger || dir.x > trigger || dir.y < -trigger || dir.x < -trigger)
            {
                Move(dir, rb, speed);
            }
            MoveAnimation(dir, anim, trigger);
            return true;
        }
        else
        {
            rb.velocity = Vector2.zero;
            anim.SetInteger("Direction", 4);
            return false;
        }
    }
    ///<summary>
    /// Animation in 4 corners
    /// </summary>
    public static void MoveAnimation(Vector2 direction, Animator anim)
    {
        if (direction.y > 0 && direction.x > 0)
        {
            anim.SetInteger("Direction", 0);
            return;
        }
        if (direction.y < 0 && direction.x > 0)
        {
            anim.SetInteger("Direction", 1);
            return;
        }
        if (direction.y < 0 && direction.x < 0)
        {
            anim.SetInteger("Direction", 2);
            return;
        }
        if (direction.x < 0 && direction.y > 0)
        {
            anim.SetInteger("Direction", 3);
            return;
        }
    }
    ///<summary>
    /// Animation in 4 direction
    /// </summary>
    public static void MoveAnimation(Vector2 direction, Animator anim, float trigger)
    {
            if (direction.y > trigger)
            {
                anim.SetInteger("Direction", 0);
                return;
            }
            if (direction.y < -trigger)
            {
                anim.SetInteger("Direction", 2);
                return;
            }
            if (direction.x > trigger)
            {
                anim.SetInteger("Direction", 1);
                return;
            }
            if (direction.x < -trigger)
            {
                anim.SetInteger("Direction", 3);
                return;
        }
    }

    public static void Move(Vector2 direction, Rigidbody2D rb, float speed = 2)
    {
        rb.velocity = speed * direction;

    }
}
