using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyReward : RewardDefault
{
    [SerializeField] private int _rewardAmount;
    public override void GetReward()
    {
        Money.instance.Add(_rewardAmount);
    }
}
