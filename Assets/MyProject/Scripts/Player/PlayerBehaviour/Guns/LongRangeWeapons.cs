using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public abstract class LongRangeWeapons : MonoBehaviour, IWeapon
{
    [SerializeField] int poolCount = 2;
    [SerializeField] Missile prefab;
    [SerializeField] private JoystickForAttack joystickForAttack;
    [SerializeField] private GameObject[] animatorsWeapons;
    [SerializeField] private GameObject[] weapons;
    [SerializeField] private Animator animatorBody;
    [SerializeField] private WeaponInfo weaponInfo;
    private PoolMono<Missile> pool;
    private void Start()
    {
         pool = new PoolMono<Missile>(prefab, poolCount, this.transform);
    }
    public virtual void StartAttack()
    {
        animatorBody.SetBool("IdleActive", false);
        Missile missile = pool.GetFreeElement();
        missile.transform.position = this.transform.position;
    }
    public virtual void Attack()
    {
        if (joystickForAttack.vectorAttack == Vector2.zero)
            return;
        if (PlayerController.isAttack)
            return;
        WeaponAttack();
        PlayerController.isAttack = true;
    }
    public virtual void EndAttack()
    {
        animatorBody.SetBool("IdleActive", true);
        animatorBody.SetInteger(weaponInfo.animationName, 4);
        weapons[0].SetActive(false);
        weapons[1].SetActive(false);
        weapons[2].SetActive(false);
        weapons[3].SetActive(false);
    }
    private void WeaponAttack()
    {
        float angle = joystickForAttack.GetAngle();
        if (joystickForAttack.vectorAttack.y > 0.5)
        {
            AttackAnimation(0);
            weapons[0].transform.rotation = Quaternion.Euler(0, 0, angle-90);
            return;
        }
        if (joystickForAttack.vectorAttack.x > 0.5)
        {
            AttackAnimation(1);
            weapons[1].transform.rotation = Quaternion.Euler(0, 0, angle);
            return;
        }
        if (joystickForAttack.vectorAttack.y < -0.5)
        {
            AttackAnimation(2);
            weapons[2].transform.rotation = Quaternion.Euler(0, 0, angle - 270);
            return;
        }
        if (joystickForAttack.vectorAttack.x < -0.5)
        {
            AttackAnimation(3);
            weapons[3].transform.rotation = Quaternion.Euler(0, 0, angle - 180);
            return;
        }
    }
    private void AttackAnimation(int direction)
    {
        weapons[direction].SetActive(true);
        animatorBody.SetInteger(weaponInfo.animationName, direction);
    }


}

