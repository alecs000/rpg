using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using TMPro.Examples;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Components;
using UnityEngine.Localization.Settings;
using UnityEngine.UI;

public class EyeReward : RewardDefault, IDataPersistence
{
    public int NumberAd = 0;
    
    [SerializeField] LocalizeStringEvent _coinsEvent;
    private LocalizedString _localCoins;
    void OnEnable()
    {
        _localCoins = _coinsEvent.StringReference;
    }
    public override void GetReward()
    {
        NumberAd++;
        _localCoins.RefreshString();
        if (NumberAd == 3)
        {
            Money.instance.Add(100);
            gameObject.SetActive(false);
        }
    }

    public void LoadData(GameData data)
    {
        NumberAd = data.NumberAdEye;
    }

    public void SaveData(GameData data)
    {
        data.NumberAdEye = NumberAd;
    }


}


