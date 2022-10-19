using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AliveDefault : MonoBehaviour, IAlive
{
    protected float hitPoints { get; set; }
    public virtual void Die() { }
    public virtual void GetDamage(float damage)
    {
        hitPoints -= damage;
        if (hitPoints <= 0)
            Die();
    }
}
