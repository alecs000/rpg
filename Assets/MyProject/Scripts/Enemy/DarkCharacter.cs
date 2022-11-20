using System.Collections;
using System.ComponentModel;
using UnityEngine;

public class DarkCharacter : AliveDefault
{
    public float Damage => _enemyInfo.Damage;

    [SerializeField] private EnemiesInfo _enemyInfo;
    [SerializeField] private float _countEnemyInSpawn = 3;
    [SerializeField] private float[] _maxMinValueArea;
    [SerializeField] private GameObject[] _throns;
    [SerializeField] private EnemySpawner _enemySpawner;
    [SerializeField] private float _spawnDeviationX = 3;
    [SerializeField] private float _spawnDeviationY = 3;

    private Animator _characterAnimator;
    private bool _isDie;
    private SpriteRenderer _characterSpriteRenderer;

    private void Start()
    {
        base._hitPoints = _enemyInfo.HP;
        _characterAnimator = GetComponent<Animator>();
        _characterSpriteRenderer = GetComponent<SpriteRenderer>();

    }
    private void Update()
    {
        Behavior();
    }
    private void Behavior()
    {

    }
    public override void GetDamage(float damage)
    {
        if (_isDie)
        {
            return;
        }
        base.GetDamage(damage);
        _characterSpriteRenderer.color = "FF0000".ToColor();
        StartCoroutine(ReturnToNormalColor());
    }
    IEnumerator ReturnToNormalColor()
    {
        yield return new WaitForSeconds(0.2f);
        _characterSpriteRenderer.color = "ffffffff".ToColor();
    }
    private void Spawn()
    {
        _enemySpawner.Spawn(GetAvalibleArea(_spawnDeviationX, _spawnDeviationY));
    }
    private void Attack()
    {
        for (int i = 0; i < _countEnemyInSpawn; i++)
        {
            Spawn();
        }
        ActiveFirstThron();
    }
    private void ActiveFirstThron()
    {
        _throns[0].SetActive(true);
    }
    private void ActiveSecondThron()
    {
        _throns[1].SetActive(true);
    }
    private void ActiveThirdThron()
    {
        _throns[2].SetActive(true);
    }
    private void DisctiveFirstThron()
    {
        _throns[0].SetActive(false);
    }
    private void DisctiveSecondThron()
    {
        _throns[1].SetActive(false);
    }
    private void DisctiveThirdThron()
    {
        _throns[2].SetActive(false);
    }


    private void EndAttack()
    {
        transform.position = GetAvalibleArea(5, 5);
    }
    private Vector2 GetAvalibleArea(float DeviationX, float DeviationY)
    {

        float numX = Random.Range(DeviationX, -DeviationX);
        float numY = Random.Range(DeviationY, -DeviationY);
        if (numY + transform.position.y > _maxMinValueArea[0])
            numY = -numY;
        if (numX + transform.position.x > _maxMinValueArea[1])
            numX = -numX;
        if (numY + transform.position.y < _maxMinValueArea[2])
            numY = -numY;
        if (numX + transform.position.x < _maxMinValueArea[3])
            numX = -numX;
        return new Vector2(numX + transform.position.x, numY + transform.position.y);
    }
    public override void Die()
    {
        _isDie = true;
        Money.instance.Add(_enemyInfo.RewardForMurder);
        _characterAnimator.SetBool("IsDie", true);
    }
}
