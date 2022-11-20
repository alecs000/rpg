using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MeleeWeapon :MonoBehaviour,  IWeapon, IDataPersistence
{
    [SerializeField] private GameObject _gameObjectCollider;
    [SerializeField] private WeaponCollider _weaponCollider;
    [SerializeField] private JoystickForAttack _joystickForAttack;
    [SerializeField] private GameObject[] _animatorsWeapons;
    [SerializeField] private Animator _animatorBody;
    [SerializeField] private WeaponInfo _weaponInfo;
    private float _damage;

    public WeaponInfo WeaponInfo => _weaponInfo;
    public virtual void StartAttack()
    {
        _animatorBody.SetBool("IdleActive", false);
    }
    public virtual void Attack()
    {
        if (_joystickForAttack.VectorAttack == Vector2.zero)
            return;
        if (PlayerController.IsAttack)
            return;
        RotateCollider();
        WeaponAnimation();
        PlayerController.IsAttack = true;
    }
    public virtual void EndAttack()
    {
        foreach (var item in _weaponCollider.Alives)
        {
            item.GetComponent<IAlive>().GetDamage(_damage);
        }
        _animatorBody.SetBool("IdleActive", true);
        _animatorBody.SetInteger(_weaponInfo.animationName, 4);
        _animatorsWeapons[0].SetActive(false);
        _animatorsWeapons[1].SetActive(false);
        _animatorsWeapons[2].SetActive(false);
        _animatorsWeapons[3].SetActive(false);
    }
        private void WeaponAnimation()
    {
        if (_joystickForAttack.VectorAttack.y > 0.5)
        {
            AttackAnimation(0);
            return;
        }
        if (_joystickForAttack.VectorAttack.x > 0.5)
        {
            AttackAnimation(1);
            return;
        }
        if (_joystickForAttack.VectorAttack.y < -0.5)
        {
            AttackAnimation(2);
            return;
        }
        if (_joystickForAttack.VectorAttack.x < -0.5)
        {
            AttackAnimation(3);
            return;
        }
    }
    private void AttackAnimation(int direction)
    {
        _animatorsWeapons[direction].SetActive(true);
        _animatorBody.SetInteger(_weaponInfo.animationName, direction);
    }

        private void RotateCollider()
    {
        float radians = (float)Math.Atan(_joystickForAttack.VectorAttack.y / _joystickForAttack.VectorAttack.x);
        float angle = (float)Math.Abs(radians * (180 / Math.PI));
        Debug.Log(angle);
        if (_joystickForAttack.VectorAttack.x < 0 && _joystickForAttack.VectorAttack.y < 0)
        {
            angle += 180;
        }
        else if (_joystickForAttack.VectorAttack.x < 0)
        {
            angle = 180 - angle;
        }
        else if (_joystickForAttack.VectorAttack.y < 0)
        {
            angle = 360 - angle;
        }
        _gameObjectCollider.transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    public void LoadData(GameData data)
    {
        if (data.WeaponsUpgrade.ContainsKey(_weaponInfo.name))
        {
            _damage = data.WeaponsUpgrade[_weaponInfo.name];
            _damage = _weaponInfo.damage;
        }
        else
        {
            _damage = _weaponInfo.damage;
        }
    }

    public void SaveData(GameData data)
    {
        
    }
}
