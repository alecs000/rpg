using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyScoreBehavior : MonoBehaviour, IDisposable
{
    private Text textMoney;
    private void Start()
    { 
        Money.instance.AddObserver(OnChangedMoney);
        textMoney = GetComponent<Text>();
        textMoney.text = Money.instance.value.ToString();
    }

    public void Dispose()
    {
        Money.instance.RemoveObserver(OnChangedMoney);
    }

    private void OnChangedMoney(object oldValue, object newValue)
    {
        textMoney.text = newValue.ToString();
    }
}
