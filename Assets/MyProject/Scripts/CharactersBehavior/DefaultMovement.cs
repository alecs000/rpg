using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.RuleTile.TilingRuleOutput;

public static class DefaultMovement
{
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
                Move(dir, rb, anim, speed);
                return true;
            }
            Move(dir, rb, anim, trigger, speed);
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
    /// Movement in 4 corners
    /// </summary>
    public static void Move(Vector2 direction, Rigidbody2D rb, Animator anim, float speed = 2)
    {
        if (direction.y > 0 || direction.x > 0 || direction.y < -0 || direction.x < -0)
        {
            Move(direction, rb, speed);
        }
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
    /// Movement in 4 direction
    /// </summary>
    public static void Move(Vector2 direction, Rigidbody2D rb, Animator anim, float trigger, float speed = 2)
    {
        if (direction.y > trigger|| direction.x > trigger|| direction.y < -trigger|| direction.x < -trigger)
        {
            Move(direction, rb, speed);
        }
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
