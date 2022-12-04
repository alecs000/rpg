using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization.Settings;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    private void Awake()
    {
        if(PlayerPrefs.GetInt("ChangeLocale")==1)
            LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[PlayerPrefs.GetInt("SelectedLocale")];
        if (PlayerPrefs.GetInt("Scene") == 0)
        {
            PlayerPrefs.SetInt("Scene", 1);
        }
        SceneManager.LoadScene(PlayerPrefs.GetInt("Scene"));
    }

}
