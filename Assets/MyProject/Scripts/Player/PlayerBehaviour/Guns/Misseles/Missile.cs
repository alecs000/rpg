using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public abstract class Missile : MonoBehaviour
{
    [SerializeField] private WeaponInfo _weapon;
    [SerializeField] private Rigidbody2D _missleRigidbody;
    [SerializeField] private float _speed;
    private JoystickForAttack _joystickForAttack;
    // Направление при появлении.
    private Vector2 _direction;
    private void OnEnable()
    {
        _joystickForAttack = GameObject.FindWithTag("_joystickForAttack").GetComponent<JoystickForAttack>();
        float rotation = _joystickForAttack.GetAngle();
        transform.rotation = Quaternion.Euler(0, 0, rotation);
        _direction = _joystickForAttack.VectorAttack;
    }
    private void FixedUpdate()
    {
        DefaultMovement.Move(_direction, _missleRigidbody, _speed);
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
            collisionGameObject.GetComponent<IAlive>().GetDamage(_weapon.damage);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

}
