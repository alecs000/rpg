using UnityEngine;
using UnityEngine.UI;

public class Money : BankDefoult, IDataPersistence
{
    [SerializeField] private GameObject _notice;
    [SerializeField] private Text _noticeText;
    public static Money instance = null;
    private int _moneyAmountOnStart;
    public int GetMoneyOnLavel()
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
        if (PlayerPrefs.GetInt("MoneyInLasLevel") > 0)
        {
            _noticeText.text = "+" + PlayerPrefs.GetInt("MoneyInLasLevel").ToString() + " coins in the last attempt";
            _notice.SetActive(true);
        }
        data.MoneyAmountOnLevel = 0;
    }

    public void SaveData(GameData data)
    {
        data.MoneyAmount = _bankValue.Value;
    }
    private void OnDisable()
    {
        PlayerPrefs.SetInt("MoneyInLasLevel", GetMoneyOnLavel());
    }
}
