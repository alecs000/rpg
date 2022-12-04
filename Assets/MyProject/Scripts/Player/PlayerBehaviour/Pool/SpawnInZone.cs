using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnInZone : MonoBehaviour
{
    [SerializeField] private float _count;
    [SerializeField] private string _layer = "Layer 1";
    [SerializeField] private EnemySpawner _enemySpawner;
    [SerializeField] private Vector2 _diviation;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            for (int i = 0; i < _count; i++)
            {
                _enemySpawner.RandomSpawn(this.transform.position, _diviation.x, _diviation.y, _layer);
            }
            this.gameObject.SetActive(false);
        }
    }
}
