using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public abstract class DefoultEnemy : AliveDefault
{
    [SerializeField] protected float speed;
    [SerializeField] protected float distance;
    [SerializeField] protected float _hitPoints;
    [SerializeField] protected float damage;
    protected SpriteRenderer spriteRenderer;
    protected Transform playerTransform;
    protected Rigidbody2D rb;
    protected PlayerController playerController;
    protected Animator anim;
    protected bool isAttack;
    protected bool isDie;
    private void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");
        playerTransform = player.transform;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>(); 
        playerController = player.GetComponent<PlayerController>();
            
    }
    private void OnEnable()
    {
        hitPoints = _hitPoints;
        isDie = false;
        isAttack=false;
    }
    private void Update()
    {
        if (isDie)
        {
            return;
        }
        Behavior();
    }
    protected virtual void Behavior()
    {

        bool isMoving = false;
        if (!isAttack)
        {
            isMoving = DefaultMovement.TryMove(this.transform.position, playerTransform.position, rb, anim, distance, speed: speed);
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
    protected virtual void EndDie()
    {  
     
    }
    protected virtual void EndAttack()
    {
        if (isDie)
        {
            return;
        }
        if (Vector3.Distance(playerTransform.position, this.transform.position) < distance)
        {
            playerController.GetDamage(damage);
        }
        isAttack = false;
        anim.SetBool("IsAttack", false);
    }

    public override void Die() {
        anim.SetBool("IsDie", true);
    }
    public override void GetDamage(float damage) {
        if (isDie)
        {
            return;
        }
        base.GetDamage(damage);
        spriteRenderer.color = "FF0000".ToColor();
        StartCoroutine(ReturnToNormalColor());
    }
    IEnumerator ReturnToNormalColor()
    {
        yield return new WaitForSeconds(0.2f);
        spriteRenderer.color = "ffffffff".ToColor();
    }
}
