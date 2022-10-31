using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MeleeWeapon :MonoBehaviour,  IWeapon
{
    [SerializeField] private GameObject gameObjectCollider;
    [SerializeField] private WeaponCollider weaponCollider;
    [SerializeField] private JoystickForAttack joystickForAttack;
    [SerializeField] private GameObject[] animatorsWeapons;
    [SerializeField] private Animator animatorBody;
    [SerializeField] private WeaponInfo weaponInfo;
    public WeaponInfo _weaponInfo => weaponInfo;
    public virtual void StartAttack()
    {
        animatorBody.SetBool("IdleActive", false);
    }
    public virtual void Attack()
    {
        if (joystickForAttack.vectorAttack == Vector2.zero)
            return;
        if (PlayerController.isAttack)
            return;
        RotateCollider();
        WeaponAnimation();
        PlayerController.isAttack = true;
    }
    public virtual void EndAttack()
    {
        foreach (var item in weaponCollider.alives)
        {
            item.GetComponent<IAlive>().GetDamage(weaponInfo.damage);
        }
        animatorBody.SetBool("IdleActive", true);
        animatorBody.SetInteger(weaponInfo.animationName, 4);
        animatorsWeapons[0].SetActive(false);
        animatorsWeapons[1].SetActive(false);
        animatorsWeapons[2].SetActive(false);
        animatorsWeapons[3].SetActive(false);
    }
        private void WeaponAnimation()
    {
        if (joystickForAttack.vectorAttack.y > 0.5)
        {
            AttackAnimation(0);
            return;
        }
        if (joystickForAttack.vectorAttack.x > 0.5)
        {
            AttackAnimation(1);
            return;
        }
        if (joystickForAttack.vectorAttack.y < -0.5)
        {
            AttackAnimation(2);
            return;
        }
        if (joystickForAttack.vectorAttack.x < -0.5)
        {
            AttackAnimation(3);
            return;
        }
    }
    private void AttackAnimation(int direction)
    {
        animatorsWeapons[direction].SetActive(true);
        animatorBody.SetInteger(weaponInfo.animationName, direction);
    }

        private void RotateCollider()
    {
        float radians = (float)Math.Atan(joystickForAttack.vectorAttack.y / joystickForAttack.vectorAttack.x);
        float angle = (float)Math.Abs(radians * (180 / Math.PI));
        Debug.Log(angle);
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
