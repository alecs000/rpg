using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;
using static UnityEditor.PlayerSettings;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private int poolCount = 2;
    [SerializeField] private AliveDefault prefab;
    [SerializeField] private bool _navMeshMovment;
    [SerializeField] private bool _simpleMovment;
    private PoolMono<AliveDefault> pool;
    private static List<IAlive> alive = new List<IAlive>();
    private void Awake()
    {
        pool = new PoolMono<AliveDefault>(prefab, poolCount, this.transform);
    }
    public void RandomSpawn(Vector2 position, float deviationX, float deviationY, string layer = "Layer 1")
    {
        Spawn(new Vector2( position.x + Random.Range(-deviationX, deviationX), position.y + Random.Range(-deviationY, deviationY)), layer);
    } 
    public void Spawn(Vector2 position, string layer = "Layer 1")
    {
        DefoultEnemy enemy = pool.GetFreeElement(false) as DefoultEnemy;
        enemy.NavMeshMovment = _navMeshMovment;
        enemy.SimpleMovment = _simpleMovment;
        enemy.transform.position = new Vector2(position.x, position.y);
        enemy.gameObject.layer = LayerMask.NameToLayer(layer);
        enemy.gameObject.GetComponent<SpriteRenderer>().sortingLayerName = layer;
        SpriteRenderer[] srs = enemy.gameObject.GetComponentsInChildren<SpriteRenderer>();
        foreach (SpriteRenderer sr in srs)
        {
            sr.sortingLayerName = layer;
        }
        enemy.gameObject.SetActive(true);
        alive.Add(enemy);
    }
}
