using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class ChestBehaviour : MonoBehaviour
{
    public int MoneyAdded;
    [SerializeField] private ChestInfo _chestInfo;
    [SerializeField] private GameObject _openedChest;
    [SerializeField] private GameObject _closedChest;
    [SerializeField] private GameObject _notification;
    [SerializeField] private AudioSource _chestAudioSource;

    private Animation _notificationAnimator;
    private void Start()
    {
        _notificationAnimator = _notification.GetComponent<Animation>();
    }
    public void Open(GameObject sender)
    {
        int moneyAmount = Random.Range(_chestInfo.MoneyAmount - _chestInfo.Diviation, _chestInfo.MoneyAmount + _chestInfo.Diviation);
        MoneyAdded=moneyAmount;
        sender.SetActive(false);
        _openedChest.SetActive(true);
        Money.instance.Add(moneyAmount);
        _notification.SetActive(true);
        _closedChest.SetActive(false);
    }
}
