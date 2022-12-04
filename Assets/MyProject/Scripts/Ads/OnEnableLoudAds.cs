using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnEnableLoudAds : MonoBehaviour
{
    [SerializeField] private RewardedAdsButton[] _rewardedAdsButton;
    private void Start()
    {
        foreach (var item in _rewardedAdsButton)
        {
            item.LoadAd();
        }
    }
}
