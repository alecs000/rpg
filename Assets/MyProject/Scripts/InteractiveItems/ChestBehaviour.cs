using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class ChestBehaviour : MonoBehaviour
{
    [SerializeField] private ChestInfo chestInfo;
    [SerializeField] private GameObject openedChest;
    [SerializeField] private GameObject closedChest;
    [SerializeField] private GameObject notification;
    [SerializeField] private Text notificationText;
    private Animation anim;
    private void Start()
    {
        anim = notification.GetComponent<Animation>();
    }
    public void Open(GameObject sender)
    {
        int moneyAmount = Random.Range(chestInfo.moneyAmount - chestInfo.diviation, chestInfo.moneyAmount + chestInfo.diviation);
        sender.SetActive(false);
        closedChest.SetActive(true);
        openedChest.SetActive(false);
        Money.instance.Add(moneyAmount);
        notificationText.color = "DDCC7A".ToColor();
        notificationText.text = $"+{moneyAmount} gold";
        notification.SetActive(true);
        StartCoroutine(CloseNotification());
    }
    IEnumerator CloseNotification()
    {
        yield return new WaitForSeconds(3);
        anim.Play();
        yield return new WaitForSeconds(1);
        notification.SetActive(false);
    }
}
