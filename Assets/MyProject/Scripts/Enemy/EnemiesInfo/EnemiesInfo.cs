using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "EnemiesInfo", menuName = "Gameplay/new EnemiesInfo")]
public class EnemiesInfo : ScriptableObject
{
    [SerializeField] private float _hp;
    [SerializeField] private float _damage;
    [SerializeField] private float _speed;
    [SerializeField] private int _rewardForMurder;

    public float HP => _hp;
    public float Damage => _damage;
    public float Speed => _speed;
    public int RewardForMurder => _rewardForMurder;
}
