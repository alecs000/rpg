using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public abstract class DefoultEnemy : AliveDefoult
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private float speed;
    [SerializeField] private float distance;
    [SerializeField] private float _hitPoints;
    [SerializeField] private float damage;
    [SerializeField] private float trigger = 0.5f;
    private Rigidbody2D rb;
    private PlayerController playerController;
    private Animator anim;
    private bool isAttack;
    private Vector2 direction;
    private void Start()
    {
        hitPoints = _hitPoints;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        playerController = playerTransform.gameObject.GetComponent<PlayerController>();

    }
    private void Update()
    {
        bool isMoving = false;
        if (!isAttack)
        {
            isMoving = DefoultMovement.TryMove(this.transform.position, playerTransform.position, rb, anim, distance, ref direction, speed: speed, trigger: trigger);
        }
        if (!isMoving)
        {
            Attack();
        }
    }
    protected virtual void Attack()
    {
        rb.velocity = Vector2.zero;
        isAttack = true;
        anim.SetBool("IsAttack", true);
    }
    protected virtual void EndAttack()
    {
        if (Vector3.Distance(playerTransform.position, this.transform.position) < distance + trigger)
        {
            playerController.GetDamage(damage);
        }
        isAttack = false;
        anim.SetBool("IsAttack", false);
    }
    public override void Die() { }
}
