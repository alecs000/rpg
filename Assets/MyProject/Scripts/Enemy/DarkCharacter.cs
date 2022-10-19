using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkCharacter : AliveDefault
{
    [SerializeField] private float _hitPoints;
    [SerializeField] private float _damage;
    [SerializeField] private float countEnemyInSpawn = 3;
    [SerializeField] private float[] maxMinValueArea;
    [SerializeField] private GameObject[] throns;
    [SerializeField] private EnemySpawner enemySpawner;
    [SerializeField] float spawnDeviationX = 3;
    [SerializeField] float spawnDeviationY = 3;
    public float damage => _damage;
    private PlayerController playerController;
    private Animator anim;
    private void Start()
    {
        hitPoints = _hitPoints;
        anim = GetComponent<Animator>();

    }
    private void Update()
    {
        Behavior();
    }
    private void Behavior()
    {

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
       return  new Vector2(numX + transform.position.x, numY + transform.position.y);
    }
    public override void Die() { }
}
