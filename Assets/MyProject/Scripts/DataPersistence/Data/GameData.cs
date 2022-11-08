using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public SerializableDictionary<string, int> weaponsBought;
    public SerializableDictionary<string, float> weaponsUpgrade;
    public int moneyAmount;

    // the values defined in this constructor will be the default values
    // the game starts with when there's no data to load
    public GameData() 
    {
        weaponsBought = new SerializableDictionary<string, int>();
        weaponsUpgrade = new SerializableDictionary<string, float>();
    }
}
