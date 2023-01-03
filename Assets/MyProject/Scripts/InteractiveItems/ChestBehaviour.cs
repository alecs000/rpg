using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class ChestBehaviour : MonoBehaviour
{
    public int MoneyAdded;
    public int Index;
    [SerializeField] private ChestInfo[] _chestInfo;
    [SerializeField] private GameObject[] _openedChest;
    [SerializeField] private GameObject[] _closedChest;
    [SerializeField] private GameObject[] _notifications;
    [SerializeField] private AudioSource[] _chestAudioSource;

    private Animation[] _notificationAnimators ;
    private void Start()
    {
        _notificationAnimators = new Animation[_notifications.Length];
        for(int i = 0; i< _notifications.Length; i++)
        {
            _notificationAnimators[i] = _notifications[i].GetComponent<Animation>();
        }
    }
    public void Open(GameObject sender)
    {
        int moneyAmount = Random.Range(_chestInfo[Index].MoneyAmount - _chestInfo[Index].Diviation, _chestInfo[Index].MoneyAmount + _chestInfo[Index].Diviation);
        MoneyAdded=moneyAmount;
        sender.SetActive(false);
        _openedChest[Index].SetActive(true);
        Money.instance.Add(moneyAmount);
        _notifications[Index].SetActive(true);
        _closedChest[Index].SetActive(false);
        _chestAudioSource[Index].Play();
    }
}
