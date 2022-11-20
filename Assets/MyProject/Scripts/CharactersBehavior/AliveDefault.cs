using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AliveDefault : MonoBehaviour, IAlive
{
    protected float _hitPoints { get; set; }
    public virtual void Die() { }
    public virtual void GetDamage(float damage)
    {
        _hitPoints -= damage;
        if (_hitPoints <= 0)
            Die();
    }
}
