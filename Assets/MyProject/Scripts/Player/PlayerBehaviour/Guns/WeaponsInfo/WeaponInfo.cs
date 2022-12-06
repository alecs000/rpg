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
    [SerializeField] private int _cost;
    [SerializeField] private AudioClip _equipAudioSource;
    public int Index => _index;
    public string NameWeapon => _nameWeapon;
    public Sprite Sprite => _sprite;
    public float Damage => _damage;
    public float AttackSpeed => _attackSpeed;
    public string AnimationName => _animationName;
    public int Cost => _cost;
    public AudioClip EquipAudioSource => _equipAudioSource;
}
