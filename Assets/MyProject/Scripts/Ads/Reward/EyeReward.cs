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
    
    public LocalizeStringEvent puzzleNameEvent;
    private LocalizedString localPuzzleName;
    public override void GetReward()
    {
        NumberAd++;
        localPuzzleName.RefreshString();
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

    void OnEnable()
    {
        localPuzzleName = puzzleNameEvent.StringReference;
        puzzleNameEvent.OnUpdateString.AddListener(OnStringChanged);
    }

    void OnStringChanged(string s)
    {
        Debug.Log($"String changed to `{s}`");
        Debug.Log("Language selected: " + LocalizationSettings.SelectedLocale);
    }
}


