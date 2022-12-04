using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public SerializableDictionary<string, int> WeaponsBought;
    public SerializableDictionary<string, float> WeaponsUpgrade;
    public int MoneyAmount;
    public int MoneyAmountOnLevel;
    public int LevelsAmount;
    public int NumberAdEye;

    // the _values defined in this constructor will be the default _values
    // the game starts with when there's no data to load
    public GameData() 
    {
        WeaponsBought = new SerializableDictionary<string, int>();
        WeaponsUpgrade = new SerializableDictionary<string, float>();
    }
}
