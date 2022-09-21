using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using static UnityEngine.Networking.UnityWebRequest;

public class AttackSwordPlayerBehaviour : IPlayerBehaviour
{
    private Animator animatorBody;
    private GameObject[] animatorSword;
    private GameObject Sword;
    private JoystickForAttack joystickForAttack;
    private Player player;
    private GameObject gameObjectCollider;

    public AttackSwordPlayerBehaviour(Animator animatorBody, JoystickForAttack joystickForAttack, Player player, GameObject gameObjectCollider, GameObject[] animatorSword, GameObject Sword)
    {
        this.animatorBody = animatorBody;
        this.joystickForAttack = joystickForAttack;
        this.player = player;
        this.gameObjectCollider = gameObjectCollider;
        this.Sword = Sword;
        this.animatorSword = animatorSword;
    }

    public void Enter()
    {
        Sword.SetActive(true);
        animatorBody.SetBool("IdleActive", false);
    }

    public void Exit()
    {
        animatorBody.SetBool("IdleActive", true);
        animatorBody.SetInteger("SwordAttack", 4);
        animatorSword[0].SetActive(false);
        animatorSword[1].SetActive(false);
        animatorSword[2].SetActive(false);
        animatorSword[3].SetActive(false);
    }

    void IPlayerBehaviour.Update()
    {
        if (joystickForAttack.vectorAttack == Vector2.zero)
            return;
        if (PlayerController.isAttack)
            return;
        RotateCollider(); 
        SwordAnimation();
        PlayerController.isAttack=true;
        if (joystickForAttack.vectorAttack == Vector2.zero)
        {
             player.SetBehaviourIdle();
        }
    }
    private void SwordAnimation()
    {
        if (joystickForAttack.vectorAttack.y > 0.5)
        {
            animatorSword[0].SetActive(true);
            animatorBody.SetInteger("SwordAttack", 0);
            return;
        }
        if (joystickForAttack.vectorAttack.x > 0.5)
        {
            animatorSword[1].SetActive(true);
            animatorBody.SetInteger("SwordAttack", 1);
            return;
        }
        if (joystickForAttack.vectorAttack.y < -0.5)
        {
            animatorSword[2].SetActive(true);
            animatorBody.SetInteger("SwordAttack", 2);
            return;
        }
        if (joystickForAttack.vectorAttack.x < -0.5)
        {
            animatorSword[3].SetActive(true);
            animatorBody.SetInteger("SwordAttack", 3);
            return;
        }
    }
    private void RotateCollider()
    {
        float radians = (float)Math.Atan(joystickForAttack.vectorAttack.y / joystickForAttack.vectorAttack.x);
        float angle = (float)Math.Abs(radians * (180 / Math.PI));
        if (joystickForAttack.vectorAttack.x < 0 && joystickForAttack.vectorAttack.y < 0)
        {
            angle += 180;
        }
        else if (joystickForAttack.vectorAttack.x < 0)
        {
            angle = 180 - angle;
        }
        else if (joystickForAttack.vectorAttack.y < 0)
        {
            angle = 360 - angle;
        }
        gameObjectCollider.transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}
