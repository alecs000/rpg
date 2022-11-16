using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEditor.Experimental.GraphView.GraphView;

public abstract class LongRangeWeapons : MonoBehaviour, IWeapon, IDataPersistence
{
    [SerializeField] int poolCount = 2;
    [SerializeField] Missile prefab;
    [SerializeField] private JoystickForAttack joystickForAttack;
    [SerializeField] private GameObject[] weapons;
    [SerializeField] private Animator animatorBody;
    [SerializeField] private WeaponInfo weaponInfo;
    private PoolMono<Missile> pool;
    private SpriteRenderer  playerSpriteRenderer;
    private float damage;
    public WeaponInfo _weaponInfo => weaponInfo;
    private void Start()
    {
         pool = new PoolMono<Missile>(prefab, poolCount, this.transform);
        playerSpriteRenderer = animatorBody.GetComponent<SpriteRenderer>();
    }
    public virtual void StartAttack()
    {
        animatorBody.SetBool("IdleActive", false);
        Missile missile = pool.GetFreeElement();
        missile.gameObject.layer = animatorBody.gameObject.layer;
        missile.gameObject.GetComponent<SpriteRenderer>().sortingLayerID = playerSpriteRenderer.sortingLayerID;
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

    public void LoadData(GameData data)
    {
        damage = data.weaponsUpgrade[weaponInfo.name];
    }

    public void SaveData(GameData data)
    {
        
    }
}

