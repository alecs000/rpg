using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityPoints : BankDefoult
{
    public override void Save()
    {
        PlayerPrefs.SetInt("AbilityPoints", bankValue.Value);
    }
}
