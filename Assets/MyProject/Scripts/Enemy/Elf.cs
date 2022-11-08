using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class Elf : DefoultEnemy
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
            isMoving = DefaultMovement.TryMove(this.transform.position, playerTransform.position, rb, anim, distance);
        }
        if (!isMoving)
        {
            Attack();
        }
    }
}
