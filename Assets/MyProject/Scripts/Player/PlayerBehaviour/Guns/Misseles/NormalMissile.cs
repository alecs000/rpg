using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalMissile : Missile
{
    protected override void MissleCollision(GameObject collisionGameObject)
    {
        base.MissleCollision(collisionGameObject);
        gameObject.SetActive(false);
    }
}
