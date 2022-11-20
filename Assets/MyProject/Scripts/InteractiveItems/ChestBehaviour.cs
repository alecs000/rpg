using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class ChestBehaviour : MonoBehaviour
{
    [SerializeField] private ChestInfo _chestInfo;
    [SerializeField] private GameObject _openedChest;
    [SerializeField] private GameObject _closedChest;
    [SerializeField] private GameObject _notification;
    [SerializeField] private Text _notificationText;
    private Animation _notificationAnimator;
    private void Start()
    {
        _notificationAnimator = _notification.GetComponent<Animation>();
    }
    public void Open(GameObject sender)
    {
        int moneyAmount = Random.Range(_chestInfo.MoneyAmount - _chestInfo.Diviation, _chestInfo.MoneyAmount + _chestInfo.Diviation);
        sender.SetActive(false);
        _closedChest.SetActive(true);
        _openedChest.SetActive(false);
        Money.instance.Add(moneyAmount);
        _notificationText.color = "DDCC7A".ToColor();
        _notificationText.text = $"+{moneyAmount} gold";
        _notification.SetActive(true);
        StartCoroutine(CloseNotification());
    }
    IEnumerator CloseNotification()
    {
        yield return new WaitForSeconds(3);
        _notificationAnimator.Play();
        yield return new WaitForSeconds(1);
        _notification.SetActive(false);
    }
}
