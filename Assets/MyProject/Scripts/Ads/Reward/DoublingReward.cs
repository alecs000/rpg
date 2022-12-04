using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoublingReward : RewardDefault
{
    [SerializeField] private Text _moneyText;
    public override void GetReward()
    {
        base.GetReward();
        Money.instance.Add(Money.instance.GetMoneyOnLevel());
        _moneyText.text = $"+{Money.instance.GetMoneyOnLevel().ToString()} coins";
    }
}
