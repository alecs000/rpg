using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class Eye : DefoultEnemy
{
    protected override void AgentBehavior()
    {
        if (_isDie)
        {
            return;
        }
        bool isMoving;
        float dis = Vector3.Distance(_playerTransform.position, this.transform.position);
        if (dis > _distance)
        {
            Vector2 dir = (_playerTransform.position - this.transform.position).normalized;
            _agent.SetDestination(_playerTransform.position);
            isMoving = true;
            if (dir.x>0)
            {
                _enemyAnimator.SetInteger("Direction", 1);
            }
            else
            {
                _enemyAnimator.SetInteger("Direction", 0);
            }
        }
        else
        {
           _enemyRigidbody.velocity = Vector2.zero;
            _enemyAnimator.SetInteger("Direction", 4);
            isMoving = false;
        }
        if (isMoving)
            _enemyAnimator.SetBool("IsAttack", false);
        if (!isMoving)
        {
            Attack();
        }
    }
    protected override void Behavior()
    {
        if (_isDie)
        {
            return;
        }
        bool isMoving;
        float dis = Vector3.Distance(_playerTransform.position, this.transform.position);
        if (dis > _distance)
        {
            Vector2 dir = (_playerTransform.position - this.transform.position).normalized;
            DefaultMovement.Move(dir,_enemyRigidbody, _enemyInfo.Speed);
            isMoving = true;
            if (dir.x > 0)
            {
                _enemyAnimator.SetInteger("Direction", 1);
            }
            else
            {
                _enemyAnimator.SetInteger("Direction", 0);
            }
        }
        else
        {
            _enemyRigidbody.velocity = Vector2.zero;
            _enemyAnimator.SetInteger("Direction", 4);
            isMoving = false;
        }
        if (isMoving)
            _enemyAnimator.SetBool("IsAttack", false);
        if (!isMoving)
        {
            Attack();
        }
    }
}
