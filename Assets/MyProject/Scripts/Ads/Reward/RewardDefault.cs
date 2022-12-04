using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RewardDefault : MonoBehaviour
{
    public virtual void GetReward()
    {
        gameObject.SetActive(false);
    }
}
