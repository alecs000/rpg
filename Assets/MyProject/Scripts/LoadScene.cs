using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization.Settings;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    private void Start()
    {
        if (!PlayerPrefs.HasKey("Scene"))
        {
            PlayerPrefs.SetInt("Scene", 1);
        }
        int scene = PlayerPrefs.GetInt("Scene");
        SceneManager.LoadScene(scene);
    }

}
