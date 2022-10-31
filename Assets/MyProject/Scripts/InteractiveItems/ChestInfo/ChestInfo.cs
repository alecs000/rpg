using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "ChestInfo", menuName = "Gameplay/new ChestInfo")]
public class ChestInfo : ScriptableObject
{
    [SerializeField] private int _moneyAmount;
    [SerializeField] private int _diviation;
    public int moneyAmount => _moneyAmount;
    public int diviation => _diviation;
}
