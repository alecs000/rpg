using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.RuleTile.TilingRuleOutput;

public static class DefoultMovement
{
    public static bool TryMove(Vector2 MoveFrom, Vector2 MoveTo, Rigidbody2D rb, Animator anim, float distance, ref Vector2 dir, float speed = 2, float trigger = 0)
    {
        float dis = Vector3.Distance(MoveTo, MoveFrom);
        dir = (MoveTo - MoveFrom).normalized;
        if (dis > distance)
        {
            Move(dir, rb, anim, speed, trigger);
            return true;
        }
        else
        {
            rb.velocity = Vector2.zero;
            anim.SetInteger("Direction", 4);
            return false;
        }
    }
    public static void Move(Vector2 direction, Rigidbody2D rb, Animator anim, float speed = 2, float trigger = 0)
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
        if (direction.x > trigger)
        {
            anim.SetInteger("Direction", 1);
            return;
        }
        if (direction.y < -trigger)
        {
            anim.SetInteger("Direction", 2);
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
