using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BankDefoult : MonoBehaviour
{
    protected ObservableVariable<int> bankValue;
    public int value => bankValue.Value;
    // Start is called before the first frame update
    void Awake()
    {
        Initialize();
    }
    protected virtual void Initialize()
    {
        bankValue = new ObservableVariable<int>();
    }

    public virtual void Add(int value)
    {
        bankValue.Value += value;
        Save();
    }

    public virtual bool Remove(int value)
    {
        if (bankValue.Value >= value)
        {
            bankValue.Value -= value;
            return true;
        }
        Save();
        return false;
    }

    public virtual void Save()
    {
    }

    public virtual void AddObserver(Action<object, object> OnChanged)
    {
        bankValue.OnChanged += OnChanged;
    }
    public virtual void RemoveObserver(Action<object, object> OnChanged)
    {
        bankValue.OnChanged -= OnChanged;
    }
}
