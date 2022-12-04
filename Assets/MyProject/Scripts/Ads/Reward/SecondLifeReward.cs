using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondLifeReward : RewardDefault
{
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private GameObject _endMenu;

    public override void GetReward()
    {
        base.GetReward();
        _playerController.gameObject.SetActive(true);
        _endMenu.gameObject.SetActive(false);
        _playerController.Revival();
    }
}
