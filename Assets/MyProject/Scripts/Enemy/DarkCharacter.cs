using System.Collections;
using System.ComponentModel;
using UnityEngine;

public class DarkCharacter : AliveDefault
{
    public float damage => _damage;

    [SerializeField] private float _hitPoints;
    [SerializeField] private float _damage;
    [SerializeField] private float countEnemyInSpawn = 3;
    [SerializeField] private float[] maxMinValueArea;
    [SerializeField] private GameObject[] throns;
    [SerializeField] private EnemySpawner enemySpawner;
    [SerializeField] float spawnDeviationX = 3;
    [SerializeField] float spawnDeviationY = 3;

    private Animator anim;
    private bool _isDie;
    private SpriteRenderer characterSpriteRenderer;

    private void Start()
    {
        hitPoints = _hitPoints;
        anim = GetComponent<Animator>();
        characterSpriteRenderer = GetComponent<SpriteRenderer>();

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
        characterSpriteRenderer.color = "FF0000".ToColor();
        StartCoroutine(ReturnToNormalColor());
    }
    IEnumerator ReturnToNormalColor()
    {
        yield return new WaitForSeconds(0.2f);
        characterSpriteRenderer.color = "ffffffff".ToColor();
    }
    private void Spawn()
    {
        enemySpawner.Spawn(GetAvalibleArea(spawnDeviationX, spawnDeviationY));
    }
    private void Attack()
    {
        for (int i = 0; i < countEnemyInSpawn; i++)
        {
            Spawn();
        }
        ActiveFirstThron();
    }
    private void ActiveFirstThron()
    {
        throns[0].SetActive(true);
    }
    private void ActiveSecondThron()
    {
        throns[1].SetActive(true);
    }
    private void ActiveThirdThron()
    {
        throns[2].SetActive(true);
    }
    private void DisctiveFirstThron()
    {
        throns[0].SetActive(false);
    }
    private void DisctiveSecondThron()
    {
        throns[1].SetActive(false);
    }
    private void DisctiveThirdThron()
    {
        throns[2].SetActive(false);
    }


    private void EndAttack()
    {
        transform.position = GetAvalibleArea(5, 5);
    }
    private Vector2 GetAvalibleArea(float DeviationX, float DeviationY)
    {

        float numX = Random.Range(DeviationX, -DeviationX);
        float numY = Random.Range(DeviationY, -DeviationY);
        if (numY + transform.position.y > maxMinValueArea[0])
            numY = -numY;
        if (numX + transform.position.x > maxMinValueArea[1])
            numX = -numX;
        if (numY + transform.position.y < maxMinValueArea[2])
            numY = -numY;
        if (numX + transform.position.x < maxMinValueArea[3])
            numX = -numX;
        return new Vector2(numX + transform.position.x, numY + transform.position.y);
    }
    public override void Die()
    {
        _isDie = true;
        anim.SetBool("IsDie", true);
    }
}
