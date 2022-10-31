using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestBehaviour : MonoBehaviour
{
    [SerializeField] ChestInfo chestInfo;
    [SerializeField] Money money;
    [SerializeField] GameObject openedChest;
    [SerializeField] GameObject closedChest;
    public void Open(GameObject sender)
    {
        sender.SetActive(false);
        closedChest.SetActive(true);
        openedChest.SetActive(false);
        money.Add(Random.Range(chestInfo.moneyAmount - chestInfo.diviation, chestInfo.moneyAmount + chestInfo.diviation));
    }
}
