using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : BankDefoult
{
    public static Money instance = null;
    private void Awake()
    {
        Initialize();
        if (instance == null)
        {
            instance = this;
        }
        else if (instance == this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(this);
    }
    protected override void Initialize()
    {
        base.Initialize();
        if (PlayerPrefs.HasKey("Money"))
        {
            bankValue.Value = PlayerPrefs.GetInt("Money");
        }
    }
    public override void Save()
    {
        PlayerPrefs.SetInt("Money", bankValue.Value);
    }
}
