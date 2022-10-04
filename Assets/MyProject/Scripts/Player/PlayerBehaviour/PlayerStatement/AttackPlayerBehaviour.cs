using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using static UnityEngine.Networking.UnityWebRequest;

public class AttackPlayerBehaviour : IPlayerBehaviour
{
    private IWeapon weapon;
    public AttackPlayerBehaviour(IWeapon weapon)
    {
        this.weapon = weapon;
    }

    public void Enter()
    {
        weapon.StartAttack();
    }

    public void Exit()
    {
        weapon.EndAttack();
    }

    void IPlayerBehaviour.Update()
    {
        weapon.Attack();
    }

}
