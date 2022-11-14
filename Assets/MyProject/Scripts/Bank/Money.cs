using Assets.MyProject.Scripts.DataPersistence;
using UnityEngine;
using UnityEngine.UI;

public class Money : BankDefoult, IDataPersistence
{
    [SerializeField] GameObject notice;
    [SerializeField] Text noticeText;
    public static Money instance = null;

    private int _moneyAmountOnLevel;

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
        bankValue.Value = data.moneyAmount;
        if (PlayerPrefs.GetInt("MoneyInLasLevel") > 0)
        {
            noticeText.text = "+" + PlayerPrefs.GetInt("MoneyInLasLevel").ToString() + " coins in the last attempt";
            notice.SetActive(true);
        }
        data.moneyAmountOnLevel = 0;
    }

    public void SaveData(GameData data)
    {
        if(_moneyAmountOnLevel==0)
            _moneyAmountOnLevel = bankValue.Value - data.moneyAmount;
        data.moneyAmount = bankValue.Value;
    }
    private void OnDisable()
    {
        PlayerPrefs.SetInt("MoneyInLasLevel", _moneyAmountOnLevel);
    }
}
