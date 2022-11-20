using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using static UnityEngine.Networking.UnityWebRequest;

public class AttackPlayerBehaviour : IPlayerBehaviour
{
    private IWeapon _weapon;
    public AttackPlayerBehaviour(IWeapon weapon)
    {
        this._weapon = weapon;
    }

    public void Enter()
    {
        _weapon.StartAttack();
    }

    public void Exit()
    {
        _weapon.EndAttack();
    }

    public void Update()
    {
        _weapon.Attack();
    }

    void IPlayerBehaviour.FixedUpdate()
    {

    }

}
