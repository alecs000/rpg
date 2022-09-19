using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSwordPlayerBehaviour : IPlayerBehaviour
{
    private Animator animator;
    private JoystickForAttack joystickForAttack;
    private Player player;
    private GameObject gameObjectCollider;
    public AttackSwordPlayerBehaviour(Animator animator, JoystickForAttack joystickForAttack, Player player, GameObject gameObjectCollider)
    {
        this.animator = animator;
        this.joystickForAttack = joystickForAttack;
        this.player = player;
        this.gameObjectCollider = gameObjectCollider;
    }

    public void Enter()
    {  
        animator.SetBool("IdleActive", false);
    }

    public void Exit()
    {
        gameObjectCollider.transform.position = player.gameObject.transform.position;
        animator.SetBool("IdleActive", true);
        animator.SetInteger("SwordAttack", 4);
    }

    void IPlayerBehaviour.Update()
    {
        gameObjectCollider.transform.position = joystickForAttack.vectorAttack+new Vector2(player.gameObject.transform.position.x, player.gameObject.transform.position.y);
        Debug.Log(gameObjectCollider.transform.position);
        if (joystickForAttack.vectorAttack.y > 0.5)
        {
            Debug.Log("ER");
            animator.SetInteger("SwordAttack", 0);
            return;
        }
        if (joystickForAttack.vectorAttack.x > 0.5)
        {
            animator.SetInteger("SwordAttack", 1);
            return;
        }
        if (joystickForAttack.vectorAttack.y < -0.5)
        {
            animator.SetInteger("SwordAttack", 2);
            return;
        }
        if (joystickForAttack.vectorAttack.x < -0.5)
        {
            animator.SetInteger("SwordAttack", 3);
            return;
        }
        if (joystickForAttack.vectorAttack == Vector2.zero)
        {
             player.SetBehaviourIdle();
        }
    }
}
