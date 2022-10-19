using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class Missile : MonoBehaviour
{
    [SerializeField] WeaponInfo weapon;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed;
    private JoystickForAttack joystickForAttack;
    private Vector2 direction;
    private void OnEnable()
    {
        joystickForAttack = GameObject.FindWithTag("JoystickForAttack").GetComponent<JoystickForAttack>();
        direction = joystickForAttack.vectorAttack.normalized;
        var rotation = joystickForAttack.GetAngle();
        transform.rotation = Quaternion.Euler(0, 0, rotation);
    }
    private void Update()
    {
        DefaultMovement.Move(direction, rb, speed);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            return;
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<IAlive>().GetDamage(weapon.damage);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
