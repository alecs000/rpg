using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "WeaponInfo", menuName = "Gameplay/new WeaponInfo")]
public class WeaponInfo : ScriptableObject
{
    [SerializeField] private float _damage;

    [SerializeField] private string _animationName;
    public float damage => _damage;
    public string animationName => _animationName;
}
