using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public abstract class Missile : MonoBehaviour
{
    [SerializeField] WeaponInfo weapon;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed;
    private JoystickForAttack joystickForAttack;
    private Vector2 _direction;//направление при появлении
    private void OnEnable()
    {
        joystickForAttack = GameObject.FindWithTag("JoystickForAttack").GetComponent<JoystickForAttack>();
        float rotation = joystickForAttack.GetAngle();
        transform.rotation = Quaternion.Euler(0, 0, rotation);
        _direction = joystickForAttack.vectorAttack;
    }
    private void FixedUpdate()
    {
        DefaultMovement.Move(_direction, rb, speed);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")|| collision.gameObject.CompareTag("InvisibleZone"))
        {
            return;
        }

        MissleCollision(collision.gameObject);
    }
    protected virtual void MissleCollision(GameObject collisionGameObject)
    {
        if (collisionGameObject.CompareTag("Enemy"))
        {
            collisionGameObject.GetComponent<IAlive>().GetDamage(weapon.damage);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

}
