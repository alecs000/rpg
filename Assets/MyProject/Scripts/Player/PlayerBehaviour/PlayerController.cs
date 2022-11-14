using Cainos.PixelArtTopDown_Basic;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class PlayerController : AliveDefault
{
    public static bool isAttack;

    [SerializeField] private GameObject[] weapons;
    [SerializeField] private Player player;
    [SerializeField] private JoystickForMovment joystickForMovment;
    [SerializeField] private JoystickForAttack JoystickForAttack;
    [SerializeField] private float _hitPoints;
    [SerializeField] private GameObject _loseMenu;

    private SpriteRenderer _spriteRenderer;
    private bool _isDie;

    private void Awake()
    {
        foreach (var item in weapons)
        {
            var weapon = item.GetComponent<IWeapon>();
            if (weapon._weaponInfo.index==PlayerPrefs.GetInt("GunIndex"))
            {
                LayerTrigger.item = item;
                player.weapon = weapon;
                item.SetActive(true);
                break;
            }
        }
    }
    private void Start()
    {
        hitPoints = _hitPoints;
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
    public void AttackEnd()
    {
        if (_isDie)
            return;
        player.SetBehaviourIdle();
        isAttack = false;
    }
    public void DieEnd()
    {
        _loseMenu.SetActive(true);
    }
    private void Update()
    {
        if (_isDie)
            return;
        if (isAttack)
            return;
        if (joystickForMovment.vectorDirection!= Vector2.zero)
        {
            player.SetBehaviourRunning();
            return;
        }

        if (JoystickForAttack.vectorAttack.x>0.5||JoystickForAttack.vectorAttack.x < -0.5 || JoystickForAttack.vectorAttack.y > 0.5 || JoystickForAttack.vectorAttack.y < -0.5)
        {
            player.SetBehaviourAttack();
            return;
        }
    }
    public override void GetDamage(float damage)
    {
        if (_isDie)
            return;
        base.GetDamage(damage);
        float colorValue = 1 / (_hitPoints / hitPoints);
        if (colorValue >= 0)
        {
            _spriteRenderer.color = new Color(1, colorValue, colorValue, 1);
        }
    }
    public override void Die()
    {
        _isDie = true;
        player.SetBehaviourDie();
    }
}
