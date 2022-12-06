using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyScoreBehavior : MonoBehaviour
{
    private Text _textMoney;
    private void Start()
    { 
        Money.instance.AddObserver(OnChangedMoney);
        _textMoney = GetComponent<Text>();
        _textMoney.text = Money.instance.Value.ToString();
    }
    
    public void OnDisable()
    {
        Money.instance.RemoveObserver(OnChangedMoney);
    }

    private void OnChangedMoney(object oldValue, object newValue)
    {
        _textMoney.text = newValue.ToString();
    }
}
