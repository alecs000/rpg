using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BankDefoult : MonoBehaviour
{
    protected ObservableVariable<int> bankValue;
    // Start is called before the first frame update
    void Start()
    {
        bankValue = new ObservableVariable<int>(0);
    }

    public virtual void Add(int value)
    {
        bankValue.Value += value;
    }

    public virtual void Remove(int value)
    {
        if (bankValue.Value >= value)
            bankValue.Value -= value;
    }

    public virtual void Save()
    {
    }

    public virtual void AddObserver(Action<object, object> OnChanged)
    {
        bankValue.OnChanged += OnChanged;
    }
}
