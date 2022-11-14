using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class Elf : DefoultEnemy
{
    protected override void AgentBehavior()
    {
        if (isDie)
        {
            return;
        }
        bool isMoving = false;
        isMoving = DefaultMovement.TryMoveAgent(this.transform.position, playerTransform.position, anim, distance, agent, false);
        if (!isMoving)
        {
            Attack();
        }
    }
    protected override void Behavior()
    {
        if (isDie)
        {
            return;
        }
        bool isMoving;
        isMoving = DefaultMovement.TryMove(this.transform.position, playerTransform.position, rb, anim, distance, speed, 0.5f);
        if (!isMoving)
        {
            Attack();
        }
    }
}
