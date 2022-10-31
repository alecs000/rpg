using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWeapon
{
    WeaponInfo _weaponInfo { get; }
    void Attack();
    void StartAttack();
    void EndAttack();
}
