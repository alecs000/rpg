using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] int poolCount = 2;
    [SerializeField] AliveDefault prefab;
    [SerializeField] float deviationX = 3;
    [SerializeField] float deviationY = 3;
    [SerializeField] Vector2 position;
    private PoolMono<AliveDefault> pool;
    private void Awake()
    {
        pool = new PoolMono<AliveDefault>(prefab, poolCount, this.transform);
    }
    public void RandomSpawn(Vector2 position, float deviationX, float deviationY)
    {
        Spawn(new Vector2( position.x + Random.Range(-deviationX, deviationX), position.y + Random.Range(-deviationY, deviationY)));
    } 
    public void Spawn(Vector2 position)
    {
        AliveDefault enemy = pool.GetFreeElement();
        enemy.transform.position = new Vector2(position.x, position.y);
    }
}
