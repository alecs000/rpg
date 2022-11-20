using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatistic : MonoBehaviour
{ 
    private static int _killedEnemies;
    public static int KilledEnemies => _killedEnemies;
    public static void KillAdd(object sender, int amount = 1 )
    {
        _killedEnemies += amount;
    }
}
