using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWatcher : MonoBehaviour
{
    private static int _enemyAlive;
    public static int EnemyAlive => _enemyAlive;
    private void Awake()
    {
        _enemyAlive = 0;    
    }
    public void OnEnable()
    {
        _enemyAlive++;
    }
    public void OnDisable()
    {
        _enemyAlive--;
    }
}
