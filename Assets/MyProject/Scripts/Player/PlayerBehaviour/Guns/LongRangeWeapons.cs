using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEditor.Experimental.GraphView.GraphView;

public abstract class LongRangeWeapons : MonoBehaviour, IWeapon, IDataPersistence
{
    [SerializeField] private int _poolCount = 2;
    [SerializeField] private Missile _prefab;
    [SerializeField] private JoystickForAttack _joystickForAttack;
    [SerializeField] private GameObject[] _weapons;
    [SerializeField] private Animator _animatorBody;
    [SerializeField] private WeaponInfo _weaponInfo;
    private PoolMono<Missile> _pool;
    private SpriteRenderer  _playerSpriteRenderer;
    private float _damage;
    public WeaponInfo WeaponInfo => _weaponInfo;
    private void Start()
    {
         _pool = new PoolMono<Missile>(_prefab, _poolCount, this.transform);
        _playerSpriteRenderer = _animatorBody.GetComponent<SpriteRenderer>();
    }
    public virtual void StartAttack()
    {
        _animatorBody.SetBool("IdleActive", false);
        Missile missile = _pool.GetFreeElement();
        missile.gameObject.layer = _animatorBody.gameObject.layer;
        missile.gameObject.GetComponent<SpriteRenderer>().sortingLayerID = _playerSpriteRenderer.sortingLayerID;
        missile.transform.position = this.transform.position;
    }
    public virtual void Attack()
    {
        if (_joystickForAttack.VectorAttack == Vector2.zero)
            return;
        if (PlayerController.IsAttack)
            return;
        WeaponAttack();
        PlayerController.IsAttack = true;
    }
    public virtual void EndAttack()
    {
        _animatorBody.SetBool("IdleActive", true);
        _animatorBody.SetInteger(_weaponInfo.animationName, 4);
        _weapons[0].SetActive(false);
        _weapons[1].SetActive(false);
        _weapons[2].SetActive(false);
        _weapons[3].SetActive(false);
    }
    private void WeaponAttack()
    {
        float angle = _joystickForAttack.GetAngle();
        if (_joystickForAttack.VectorAttack.y > 0.5)
        {
            AttackAnimation(0);
            _weapons[0].transform.rotation = Quaternion.Euler(0, 0, angle-90);
            return;
        }
        if (_joystickForAttack.VectorAttack.x > 0.5)
        {
            AttackAnimation(1);
            _weapons[1].transform.rotation = Quaternion.Euler(0, 0, angle);
            return;
        }
        if (_joystickForAttack.VectorAttack.y < -0.5)
        {
            AttackAnimation(2);
            _weapons[2].transform.rotation = Quaternion.Euler(0, 0, angle - 270);
            return;
        }
        if (_joystickForAttack.VectorAttack.x < -0.5)
        {
            AttackAnimation(3);
            _weapons[3].transform.rotation = Quaternion.Euler(0, 0, angle - 180);
            return;
        }
    }
    private void AttackAnimation(int direction)
    {
        _weapons[direction].SetActive(true);
        _animatorBody.SetInteger(_weaponInfo.animationName, direction);
    }

    public void LoadData(GameData data)
    {
        _damage = data.WeaponsUpgrade[_weaponInfo.name];
    }

    public void SaveData(GameData data)
    {
        
    }
}

