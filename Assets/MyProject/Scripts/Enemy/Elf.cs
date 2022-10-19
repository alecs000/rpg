using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class Elf : DefoultEnemy
{
    protected override void Behavior()
    {
        bool isMoving = false;
        if (!isAttack)
        {
            isMoving = DefaultMovement.TryMove(this.transform.position, playerTransform.position, rb, anim, distance, speed: speed, 0.5f);
        }
        if (!isMoving)
        {
            Attack();
        }
    }
}
