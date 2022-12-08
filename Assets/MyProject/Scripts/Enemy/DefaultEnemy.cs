using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public abstract class DefoultEnemy : AliveDefault
{
    public bool NavMeshMovment;
    public bool SimpleMovment;

    [SerializeField] protected float _distance;
    [SerializeField] protected EnemiesInfo _enemyInfo;

    protected SpriteRenderer _enemySpriteRenderer;
    protected Transform _playerTransform;
    protected Rigidbody2D _enemyRigidbody;
    protected PlayerController playerController;
    protected Animator _enemyAnimator;
    protected bool _isAttack;
    protected bool _isDie;
    protected NavMeshAgent _agent;
    protected bool _isSpawn = true;
    private void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");
        _playerTransform = player.transform;
        _enemyRigidbody = GetComponent<Rigidbody2D>();
        _enemyAnimator = GetComponent<Animator>();
        _enemySpriteRenderer = GetComponent<SpriteRenderer>();
        playerController = player.GetComponent<PlayerController>();
        if (NavMeshMovment)
        {
            _agent = GetComponent<NavMeshAgent>();
            _agent.enabled = true;
            _agent.updateRotation = false;
            _agent.updateUpAxis = false;
            _isSpawn = false;
        }
    }
    private void OnEnable()
    {
        base._hitPoints = _enemyInfo.HP;
        _isDie = false;
        _isAttack = false;
        if (NavMeshMovment && !_isSpawn)
            _agent.enabled = true;
    }
    private void OnDisable()
    {
        if (NavMeshMovment && !_isSpawn)
            _agent.enabled = false;
    }
    private void FixedUpdate()
    {
        if (_isDie)
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
        if (_isDie)
        {
            return;
        }
        bool isMoving;
        isMoving = DefaultMovement.TryMoveAgent(this.transform.position, _playerTransform.position, _enemyAnimator, _distance, _agent);
        _isAttack = false;
        if (isMoving)
            _enemyAnimator.SetBool("IsAttack", false);
        if (!isMoving)
        {
            Attack();
        }
    }
    protected virtual void Behavior()
    {
        if (_isDie)
        {
            return;
        }
        bool isMoving;
        isMoving = DefaultMovement.TryMove(this.transform.position, _playerTransform.position, _enemyRigidbody, _enemyAnimator, _distance, _enemyInfo.Speed);
        if (isMoving)
            _enemyAnimator.SetBool("IsAttack", false);
        if (!isMoving)
        {
            Attack();
        }
    }
    protected virtual void SimpleBehavior()
    {
        if (_isDie)
        {
            return;
        }
        if (!_isAttack)
        {
            DefaultMovement.Move(Vector2.left, _enemyRigidbody, _enemyInfo.Speed);
            _enemyAnimator.SetInteger("Direction", 3);
        }
        else
        {
            _enemyAnimator.SetInteger("Direction", 4);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (SimpleMovment && collision.CompareTag("AttackTrigger"))
        {
            Attack();
        }
    }
    protected virtual void Attack()
    {
        if (_isDie)
        {
            return;
        }
        _enemyRigidbody.velocity = Vector2.zero;
        _isAttack = true;
        _enemyAnimator.SetBool("IsAttack", true);
    }
    protected virtual void EndDie()
    {
        EnemyStatistic.KillAdd(this);
        this.gameObject.SetActive(false);
    }
    protected virtual void EndAttack()
    {
        if (_isDie)
        {
            return;
        }
        if (SimpleMovment)
        {
            playerController.Die();
            return;
        }
        if (Vector3.Distance(_playerTransform.position, this.transform.position) < _distance)
        {
            playerController.GetDamage(_enemyInfo.Damage);
        }
        _isAttack = false;
        _enemyAnimator.SetBool("IsAttack", false);
    }

    public override void Die()
    {
        _isDie = true;
        _enemyAnimator.SetBool("IsDie", true);
        _enemyAnimator.SetBool("IsAttack", false);
        _enemyAnimator.SetInteger("Direction", 4);
        _enemyRigidbody.velocity = Vector2.zero;
        Money.instance.Add(_enemyInfo.RewardForMurder);
    }
    public override void GetDamage(float damage)
    {
        if (_isDie)
        {
            return;
        }
        base.GetDamage(damage);
        _enemySpriteRenderer.color = "FF0000".ToColor();
        StartCoroutine(ReturnToNormalColor());
    }
    IEnumerator ReturnToNormalColor()
    {
        yield return new WaitForSeconds(0.2f);
        _enemySpriteRenderer.color = "ffffffff".ToColor();
    }
}
