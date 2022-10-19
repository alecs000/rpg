using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : AliveDefault
{
    [SerializeField] private Player player;
    [SerializeField] private JoystickForMovment joystickForMovment;
    [SerializeField] private JoystickForAttack JoystickForAttack;
    [SerializeField] private Sword sword;
    [SerializeField] private Pistol pistol;
    [SerializeField] private Rifle rifle;
    [SerializeField] private float _hitPoints;
    public static bool isAttack;
    private void Awake()
    {
        player.weapon = pistol;
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
