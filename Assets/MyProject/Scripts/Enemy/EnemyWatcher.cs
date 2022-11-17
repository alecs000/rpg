using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWatcher : MonoBehaviour
{
    private static int _enemyAlive = 0;
    public static int EnemyAlive => _enemyAlive;
    public void OnEnable()
    {
        _enemyAlive++;
    }
    public void OnDisable()
    {
        _enemyAlive--;
    }
}
