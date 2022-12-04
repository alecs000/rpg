using UnityEngine;
using UnityEngine.UI;

public class Money : BankDefoult, IDataPersistence
{
    public static Money instance = null;
    private int _moneyAmountOnStart;
    public int GetMoneyOnLevel()
    {
        return Value - _moneyAmountOnStart;
    }
    private void Awake()
    {
        Initialize();
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(this);
    }
    public void LoadData(GameData data)
    {
        _moneyAmountOnStart = data.MoneyAmount;
        _bankValue.Value = data.MoneyAmount;
        if (PlayerPrefs.GetInt("MoneyInLastLevel") > 0)
        {
            ShowNotice notice = FindObjectOfType<ShowNotice>(true);
            notice?.Show();
        }
        data.MoneyAmountOnLevel = 0;
        PlayerPrefs.SetInt("MoneyInLastLevel", 0);
    }

    public void SaveData(GameData data)
    {
        data.MoneyAmount = Value;
    }
    private void OnDisable()
    {
        if (PlayerPrefs.GetInt("MoneyInLastLevel") != -1)
            PlayerPrefs.SetInt("MoneyInLastLevel", GetMoneyOnLevel());
    }
}
