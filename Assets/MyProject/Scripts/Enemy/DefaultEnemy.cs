using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;
using UnityEngine.XR;

public abstract class DefoultEnemy : AliveDefault
{
    public bool NavMeshMovment;
    public bool SimpleMovment;
    [SerializeField] protected float distance;
    [SerializeField] protected float _hitPoints;
    [SerializeField] protected float damage;
    [SerializeField] protected float speed = 2;
    protected SpriteRenderer spriteRenderer;
    protected Transform playerTransform;
    protected Rigidbody2D rb;
    protected PlayerController playerController;
    protected Animator anim;
    protected bool isAttack;
    protected bool isDie;
    protected NavMeshAgent agent;
    protected bool _isSpawn = true;
    private void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");
        playerTransform = player.transform;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>(); 
        playerController = player.GetComponent<PlayerController>(); 
        if (NavMeshMovment)
        {
            agent = GetComponent<NavMeshAgent>();
            agent.enabled = true;
            agent.updateRotation = false;
            agent.updateUpAxis = false;
            _isSpawn = false;
        }
    }
    private void OnEnable()
    {
        hitPoints = _hitPoints;
        isDie = false;
        isAttack=false;
        if(NavMeshMovment && !_isSpawn)
            agent.enabled = true;
    }
    private void OnDisable()
    {
        if (NavMeshMovment && !_isSpawn)
            agent.enabled = false;
    }
    private void FixedUpdate()
    {
        if (isDie)
        {
            return;
        }
        if (NavMeshMovment)
        {
            AgentBehavior();
        }
        else if (!SimpleMovment)
        {
            Behavior();
        }
        else
        {
            SimpleBehavior();
        }
    }
    protected virtual void AgentBehavior()
    {
        if (isDie)
        {
            return;
        }
        bool isMoving;
        isMoving = DefaultMovement.TryMoveAgent(this.transform.position, playerTransform.position, anim, distance, agent);
        isAttack = false;
        if (isMoving)
            anim.SetBool("IsAttack", false);
        if (!isMoving)
        {
            Attack();
        }
    }
    protected virtual void Behavior()
    {
        if (isDie)
        {
            return;
        }
        bool isMoving;
        isMoving = DefaultMovement.TryMove(this.transform.position, playerTransform.position,rb, anim, distance, speed);
        if(isMoving)
            anim.SetBool("IsAttack", false);
        if (!isMoving)
        {
            Attack();
        }
    }
    protected virtual void SimpleBehavior()
    {
        if (isDie)
        {
            return;
        }
        if (!isAttack)
        {
            DefaultMovement.Move(Vector2.left, rb, speed);
            DefaultMovement.MoveAnimation(new Vector2(-0.5f, -0.5f), anim);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (SimpleMovment&&collision.CompareTag("AttackTrigger"))
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
        EnemyStatistic.KillAdd(this);
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
