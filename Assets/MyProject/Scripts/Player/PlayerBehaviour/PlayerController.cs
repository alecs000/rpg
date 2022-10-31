using Cainos.PixelArtTopDown_Basic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class PlayerController : AliveDefault
{
    [SerializeField] private GameObject[] weapons;
    [SerializeField] private Player player;
    [SerializeField] private JoystickForMovment joystickForMovment;
    [SerializeField] private JoystickForAttack JoystickForAttack;
    [SerializeField] private float _hitPoints;
    public static bool isAttack;
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
    }
    public void AttackEnd()
    {
        player.SetBehaviourIdle();
        isAttack = false;
    }
    void Update()
    {
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
}
