using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnInZone : MonoBehaviour
{
    [SerializeField] float count;
    [SerializeField] string layer = "Layer 1";
    [SerializeField] EnemySpawner enemySpawner;
    [SerializeField] Vector2 diviation;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            for (int i = 0; i < count; i++)
            {
                enemySpawner.RandomSpawn(this.transform.position, diviation.x, diviation.y, layer);
            }
            this.gameObject.SetActive(false);
        }
    }
}
