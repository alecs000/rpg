using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class Eye : DefoultEnemy
{
    protected override void Behavior()
    {
        if (isDie)
        {
            return;
        }
        bool isMoving = false;
        if (!isAttack)
        {
            float dis = Vector3.Distance(playerTransform.position, this.transform.position);
            if (dis > distance)
            {
                Vector2 dir = (playerTransform.position - this.transform.position).normalized;
                DefaultMovement.Move(dir, rb, speed);
                isMoving = true;
                if (dir.x>0)
                {
                    anim.SetInteger("Direction", 1);
                }
                else
                {
                    anim.SetInteger("Direction", 0);
                }
            }
            else
            {
                rb.velocity = Vector2.zero;
                anim.SetInteger("Direction", 4);
                isMoving = false;
            }
        }
        if (!isMoving)
        {
            Attack();
        }
    }
    private void FixedUpdate()
    {
        Behavior();
    }
}
