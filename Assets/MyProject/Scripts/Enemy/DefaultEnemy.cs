using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;
using UnityEngine.XR;

public abstract class DefoultEnemy : AliveDefault
{
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
    protected NavMeshAgent agent;
    protected bool spawn = true;
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        spawn = false;
    }
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
        if(!spawn)
            agent.enabled = true;
    }
    private void OnDisable()
    {
        if (!spawn)
            agent.enabled = false;
    }
    private void FixedUpdate()
    {
        if (isDie)
        {
            return;
        }

        Behavior();
    }
    protected virtual void Behavior()
    {
        Vector2 MoveTo = playerTransform.position;
        Vector2 MoveFrom = transform.position;

        if (isDie)
        {
            return;
        }
        bool isMoving = false;
        float dis = Vector3.Distance(MoveTo, MoveFrom);
        Vector2 direction = (MoveTo - MoveFrom).normalized;
        if (dis > distance)
        {
            anim.SetBool("IsAttack", false);
            if (direction.y > 0 || direction.x > 0 || direction.y < -0 || direction.x < -0)
            {
                agent.SetDestination(playerController.transform.position);
            }
            if (direction.y > 0 && direction.x > 0)
            {
                anim.SetInteger("Direction", 0);
                return;
            }
            if (direction.y < 0 && direction.x > 0)
            {
                anim.SetInteger("Direction", 1);
                return;
            }
            if (direction.y < 0 && direction.x < 0)
            {
                anim.SetInteger("Direction", 2);
                return;
            }
            if (direction.x < 0 && direction.y > 0)
            {
                anim.SetInteger("Direction", 3);
                return;
            }
            isMoving = true;
        }
        else
        {
            rb.velocity = Vector2.zero;
            anim.SetInteger("Direction", 4);
            isMoving = false;
        }
        if (!isMoving)
        {
            Attack();
        }
    }
    protected virtual void Attack()
    {
        if (isDie)
        {
            return;
        }
        rb.velocity = Vector2.zero;
        isAttack = true;
        anim.SetBool("IsAttack", true);
    }
    protected virtual void EndDie()
    {  
     this.gameObject.SetActive(false);
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
        anim.SetBool("IsAttack", false);
        anim.SetInteger("Direction", 4);
        rb.velocity = Vector2.zero;
        isDie = true;
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
