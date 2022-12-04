using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowNotice : MonoBehaviour
{
    public int MoneyInLastLevel;
    [SerializeField] private GameObject _notice;
    [SerializeField] private Text _noticeText;
    public void Show()
    {
        MoneyInLastLevel = PlayerPrefs.GetInt("MoneyInLastLevel");
        _notice.SetActive(true);
    }
}
