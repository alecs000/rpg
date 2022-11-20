using Cainos.PixelArtTopDown_Basic;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : AliveDefault
{
    public static bool IsAttack;

    [SerializeField] private GameObject[] _weapons;
    [SerializeField] private Player _player;
    [SerializeField] private JoystickForMovment _joystickForMovment;
    [SerializeField] private JoystickForAttack _joystickForAttack;
    [SerializeField] private float _hitPointsStartValue;
    [SerializeField] private GameObject _loseMenu;
    [SerializeField] private Text _loseTextMoney;

    private SpriteRenderer _spriteRenderer;
    private bool _isDie;

    private void Awake()
    {
        foreach (var item in _weapons)
        {
            var weapon = item.GetComponent<IWeapon>();
            if (weapon.WeaponInfo.index==PlayerPrefs.GetInt("GunIndex"))
            {
                LayerTrigger.item = item;
                _player.Weapon = weapon;
                item.SetActive(true);
                break;
            }
        }
    }
    private void Start()
    {
        base._hitPoints = _hitPointsStartValue;
        _spriteRenderer = GetComponent<SpriteRenderer>();
        IsAttack = false;
    }
    public void AttackEnd()
    {
        if (_isDie)
            return;
        _player.SetBehaviourIdle();
        IsAttack = false;
    }
    public void DieEnd()
    {
        _loseMenu.SetActive(true);
    }
    private void Update()
    {
        if (_isDie)
            return;
        if (IsAttack)
            return;
        if (_joystickForMovment.VectorDirection!= Vector2.zero)
        {
            _player.SetBehaviourRunning();
            return;
        }

        if (_joystickForAttack.VectorAttack.x>0.5||_joystickForAttack.VectorAttack.x < -0.5 || _joystickForAttack.VectorAttack.y > 0.5 || _joystickForAttack.VectorAttack.y < -0.5)
        {
            _player.SetBehaviourAttack();
            return;
        }
    }
    public override void GetDamage(float damage)
    {
        if (_isDie)
            return;
        base.GetDamage(damage);
        float colorValue = 1 / (_hitPointsStartValue / base._hitPoints);
        if (colorValue >= 0)
        {
            _spriteRenderer.color = new Color(1, colorValue, colorValue, 1);
        }
    }
    public override void Die()
    {
        _isDie = true;
        _loseTextMoney.text = $"+{Money.instance.GetMoneyOnLavel().ToString()} coins";
        _player.SetBehaviourDie();
    }
}
