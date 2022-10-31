using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "WeaponInfo", menuName = "Gameplay/new WeaponInfo")]
public class WeaponInfo : ScriptableObject
{
    [SerializeField] private int _index;
    [SerializeField] private string _nameWeapon;
    [SerializeField] private Sprite _sprite;
    [SerializeField] private float _damage;
    [SerializeField] private float _attackSpeed;
    [SerializeField] private string _animationName;

    public int index => _index;
    public string nameWeapon => _nameWeapon;
    public Sprite sprite => _sprite;
    public float damage => _damage;
    public float attackSpeed => _attackSpeed;
    public string animationName => _animationName;
}
