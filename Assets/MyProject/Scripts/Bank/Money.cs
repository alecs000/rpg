using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : BankDefoult
{
    public override void Save()
    {
        PlayerPrefs.SetInt("Money", bankValue.Value);
    }
}
